using System.Configuration;
using System.Data;
using System.Windows;

namespace Quicklaunch
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if(string.IsNullOrEmpty(Quicklaunch.Properties.Settings.Default.folder))
            {
                var folder = $"c:\\users\\{Environment.UserName}\\toolbar";
                if(!System.IO.Directory.Exists(folder))
                System.IO.Directory.CreateDirectory(folder);

                Quicklaunch.Properties.Settings.Default.folder = folder;
                Quicklaunch.Properties.Settings.Default.Save();

            }
        
                var mainWindow = new MainWindow();
                  }
        }
    }


