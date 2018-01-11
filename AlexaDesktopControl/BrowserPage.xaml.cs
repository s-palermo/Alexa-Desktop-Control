using CefSharp;
using CefSharp.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static AlexaDesktopControl.JSBoundObject;

namespace AlexaDesktopControl
{
    /// <summary>
    /// Interaction logic for BrowserPage.xaml
    /// </summary>
    public partial class BrowserPage : Page
    {
        public BrowserPage()
        {
            InitializeComponent();
            browser.RegisterAsyncJsObject("boundAsync", new AsyncBoundObject(), BindingOptions.DefaultBinder); //default binder
            browser.RenderProcessMessageHandler = new RenderProcessMessageHandler();            
        }
        
    }
}
