using System;
using System.Collections.Generic;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;

namespace AlexaDesktopControl
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static AlexaCommands AlexaCommands;

        private App()
        {
            LoadCommands();
            foreach (string key in AlexaCommands.CommandList.Keys)
            {
                Console.WriteLine(key);
            }
        }
        private void LoadCommands()
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(AlexaDesktopControl.Properties.Settings.Default.Commands)))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    AlexaCommands = (AlexaCommands)bf.Deserialize(ms);
                    Console.WriteLine("Commands Loaded");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Commands Failed to Load:" + ex.Message);
                AlexaCommands = new AlexaCommands();
            }
        }

        public static void SaveCommands()
        {   
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, AlexaCommands);
                ms.Position = 0;
                byte[] buffer = new byte[(int)ms.Length];
                ms.Read(buffer, 0, buffer.Length);
                AlexaDesktopControl.Properties.Settings.Default.Commands = Convert.ToBase64String(buffer);
                AlexaDesktopControl.Properties.Settings.Default.Save();
            }
            Console.WriteLine("Commands Saved.");
        }
    }
}
