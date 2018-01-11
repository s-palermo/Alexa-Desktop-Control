using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

namespace AlexaDesktopControl
{
    /// <summary>
    /// Interaction logic for CommandsPage.xaml
    /// </summary>
    public partial class CommandsPage : Page
    {        
        public CommandsPage()
        {
            //App.SaveCommands(new AlexaCommands());               
            InitializeComponent();
            ListCommands();
        }

        private void AddCmdBtn_Click(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrWhiteSpace(AlexaCmdTxt.Text) || String.IsNullOrWhiteSpace(DesktopCmdTxt.Text))
            {
                MessageBox.Show("Both commands must contain a value.");
                return;
            }

            CreateCommand(AlexaCmdTxt.Text, DesktopCmdTxt.Text);
            App.AlexaCommands.CommandList.Add(AlexaCmdTxt.Text, DesktopCmdTxt.Text);
            App.SaveCommands();
            AlexaCmdTxt.Text = "";
            DesktopCmdTxt.Text = "";
        }

        private void RemoveCmdBtn_Click(object sender, RoutedEventArgs e)
        {
            Button removeBtn = (Button)sender;
            int position = Int32.Parse(removeBtn.Tag.ToString());
            TextBox alexaCommandTxt = CommandsGrid.Children.OfType<TextBox>().Where(x => x.Name.ToString() == "AlexaCmdTxt" + position).FirstOrDefault();
            TextBox desktopCommandTxt = CommandsGrid.Children.OfType<TextBox>().Where(x => x.Name.ToString() == "DesktopCmdTxt" + position).FirstOrDefault();
            RowDefinition row = CommandsGrid.RowDefinitions.Where(x => x.Name.ToString() == "RowDef" + position).FirstOrDefault();
            App.AlexaCommands.CommandList.Remove(alexaCommandTxt.Text);
            App.SaveCommands();
            CommandsGrid.Children.Remove(alexaCommandTxt);
            CommandsGrid.Children.Remove(desktopCommandTxt);
            CommandsGrid.Children.Remove((Button)sender);

            if (CommandsGrid.RowDefinitions.Count != position + 1)//update row position
            {
                foreach (UIElement ui in CommandsGrid.Children)
                {
                    int rowIndex = System.Windows.Controls.Grid.GetRow(ui);
                    if(rowIndex > position)
                    {
                        System.Windows.Controls.Grid.SetRow(ui, rowIndex-1);
                    }
                }
            }
            CommandsGrid.RowDefinitions.Remove(row);            
        }

        private void CreateCommand(string alexaCommand,string desktopCommand)
        {
            RowDefinition row = new RowDefinition()
            {
                Height = new GridLength(25),
                Name = "RowDef" + CommandsGrid.RowDefinitions.Count
            };
            CommandsGrid.RowDefinitions.Add(row);
            TextBox textBox = new TextBox()
            {
                Text = alexaCommand,
                Margin = new Thickness(3),
                IsReadOnly = true,
                Name = "AlexaCmdTxt" + (CommandsGrid.RowDefinitions.Count - 1)
            };
            CommandsGrid.Children.Add(textBox);
            Grid.SetRow(textBox, CommandsGrid.RowDefinitions.Count - 1);
            Grid.SetColumn(textBox, 0);
            TextBox textBox2 = new TextBox()
            {
                Text = desktopCommand,
                Margin = new Thickness(3),
                IsReadOnly = true,
                Name = "DesktopCmdTxt" + (CommandsGrid.RowDefinitions.Count - 1)
            };
            CommandsGrid.Children.Add(textBox2);
            Grid.SetRow(textBox2, CommandsGrid.RowDefinitions.Count - 1);
            Grid.SetColumn(textBox2, 1);
            Button button = new Button()
            {
                BorderThickness = new Thickness(0),
                Style = FindResource("ImageBtnStyle") as Style,
                Content = new Image
                {
                    Source = new BitmapImage(new Uri("/AlexaDesktopControl;component/Images/remove.png", UriKind.Relative)),
                    VerticalAlignment = VerticalAlignment.Center
                },
                Margin = new Thickness(3),
                Tag = (CommandsGrid.RowDefinitions.Count - 1)
            };
            button.Click += (RemoveCmdBtn_Click);
            CommandsGrid.Children.Add(button);
            Grid.SetRow(button, CommandsGrid.RowDefinitions.Count - 1);
            Grid.SetColumn(button, 2);
        }

        private void ListCommands()
        {
            foreach(string key in App.AlexaCommands.CommandList.Keys)
            {
                string outVal;
                App.AlexaCommands.CommandList.TryGetValue(key, out outVal);
                CreateCommand(key, outVal);
            }
        }
    }
}
