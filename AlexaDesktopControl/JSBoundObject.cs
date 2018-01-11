using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexaDesktopControl
{
    class JSBoundObject
    {
        public class AsyncBoundObject
        {
            //We expect an exception here, so tell VS to ignore
            [DebuggerHidden]
            public void Error()
            {
                throw new Exception("This is an exception coming from C#");
            }            

            [DebuggerHidden]
            public void Log(string message)
            {
                Console.WriteLine(message);
            }

            [DebuggerHidden]
            public void NewDialogItem(string alexaRequest)
            {
                Console.WriteLine(alexaRequest);
                AlexaRequestHandler.ProcessRequest(alexaRequest);
            }

            [DebuggerHidden]
            public void DisableBrowser()
            {
                MainWindow.__mainWindow.Dispatcher.Invoke(new Action(delegate ()
                {
                    MainWindow.__browserPage.browser.IsEnabled = false;
                }));
            }

            [DebuggerHidden]
            public void Minimize()
            {
                MainWindow.__mainWindow.Dispatcher.Invoke(new Action(delegate ()
                {
                    MainWindow.__mainWindow.WindowState = System.Windows.WindowState.Minimized;
                }));                
            }
        }
    }
}
