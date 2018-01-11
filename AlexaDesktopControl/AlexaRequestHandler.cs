using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexaDesktopControl
{
    class AlexaRequestHandler
    {
        public static void StartHDMeeting()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C start zoombvn://meeting.broadviewnet.com/join?confno=11119227738";
            process.StartInfo = startInfo;
            process.Start();
        }

        public static void ProcessRequest(string alexaRequest)
        {
            string desktopCommand;
            App.AlexaCommands.CommandList.TryGetValue(alexaRequest, out desktopCommand);
            if(desktopCommand != null)
            {
                RunCommand(desktopCommand);
            }
        }

        private static void RunCommand(string command)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C " + command;
            process.StartInfo = startInfo;
            process.Start();
        }
    }
}
