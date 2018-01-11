using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexaDesktopControl
{
    class RenderProcessMessageHandler : IRenderProcessMessageHandler
    {
        public void OnContextCreated(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {
            var jsCode = System.IO.File.ReadAllText(Environment.CurrentDirectory + @"\Scripts\app.js");
            var jQuery = System.IO.File.ReadAllText(Environment.CurrentDirectory + @"\Scripts\jquery-3.2.1.min.js");

            frame.ExecuteJavaScriptAsync(jQuery);
            frame.ExecuteJavaScriptAsync(jsCode);
        }

        public void OnContextReleased(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {
            
        }

        public void OnFocusedNodeChanged(IWebBrowser browserControl, IBrowser browser, IFrame frame, IDomNode node)
        {
            
        }
    }
}
