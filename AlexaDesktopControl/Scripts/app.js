boundAsync.log("Loading JS");
document.addEventListener('DOMContentLoaded', function () {

    $(document).ready(function () {
        boundAsync.log("Jquery Loaded on " + window.location.href);
        if (window.location.href == 'https://alexa.amazon.com/spa/index.html')
        {
            boundAsync.minimize();
            boundAsync.disableBrowser();
            window.location = 'https://alexa.amazon.com/spa/index.html#settings/dialogs';
        }

        var observer = new MutationObserver(function (mutations) {
            mutations.forEach(function (mutation) {
                //console.log(mutation);
                for (var i = 0; i < mutation.addedNodes.length; i++) {
                    // do things to your newly added nodes here
                    var node = mutation.addedNodes[i];
                    if (node.className == 'd-dialog-item') {
                        boundAsync.newDialogItem($($(node)[0].childNodes[1].childNodes[1]).text());
                    }
                }
            })
        });

        observer.observe(document.body, {
            childList: true,
            subtree: true,
            attributes: true
        });

    });
});