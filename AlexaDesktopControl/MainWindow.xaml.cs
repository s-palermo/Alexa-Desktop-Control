using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Navigation;

namespace AlexaDesktopControl
{    
    public partial class MainWindow : NavigationWindow
    {
        public static MainWindow __mainWindow;
        public static CommandsPage __commandsPage = new CommandsPage();
        public static BrowserPage __browserPage = new BrowserPage();
        public MainWindow()
        {
            InitializeComponent();
            NavigationService.Navigate(__browserPage);
            CenterWindowOnScreen();

            NotifyIcon ni = new System.Windows.Forms.NotifyIcon();
            ni.Text = "Alexa Desktop Control";
            ni.Icon = new System.Drawing.Icon(@"Images/toolbar.ico");
            ni.Visible = true;
            ni.MouseDoubleClick += ni_DoubleClick;
            ContextMenu cm = new ContextMenu();
            MenuItem amazonMenuItem = new MenuItem();
            MenuItem commandsMenuItem = new MenuItem();
            MenuItem exitMenuItem = new MenuItem();

            // Initialize menuItem1
            amazonMenuItem.Index = 0;
            amazonMenuItem.Text = "Alexa Dialog";
            amazonMenuItem.Click += new System.EventHandler(Amazon_Click);

            commandsMenuItem.Index = 1;
            commandsMenuItem.Text = "Commands Configuration";
            commandsMenuItem.Click += new System.EventHandler(Commands_Click);

            exitMenuItem.Index = 2;
            exitMenuItem.Text = "Exit";
            exitMenuItem.Click += new System.EventHandler(Exit_Click);

            cm.MenuItems.AddRange(
                    new System.Windows.Forms.MenuItem[] { amazonMenuItem, commandsMenuItem, exitMenuItem });

            ni.ContextMenu = cm;

            __mainWindow = this;
        }

        private void Amazon_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(__browserPage);
            this.Show();
            this.WindowState = WindowState.Normal;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Commands_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(__commandsPage);
            this.Show();
            this.WindowState = WindowState.Normal;
        }

        private void ni_DoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //this.Show();
            //this.WindowState = WindowState.Normal;
        }

        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == System.Windows.WindowState.Minimized)
                this.Hide();

            base.OnStateChanged(e);
        }

        private void CenterWindowOnScreen()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        private void NavigationWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
