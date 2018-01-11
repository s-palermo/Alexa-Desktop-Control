using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexaDesktopControl
{
    [Serializable]
    public class AlexaCommands
    {
        public Dictionary<string, string> CommandList { get; set; } = new Dictionary<string, string>();        
    }
}
