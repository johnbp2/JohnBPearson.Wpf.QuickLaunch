using Quicklaunch.Services;
using System.Windows;

namespace Quicklaunch
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {


        private void Application_Startup(object sender, StartupEventArgs e)
        {

          
                // Environment.GetFolderPath(Environment.SpecialFolder.)
                if (!System.IO.Directory.Exists(Quicklaunch.Properties.Settings.Default.folder))
                {

                    var folder = $"c:\\users\\{Environment.UserName}\\toolbar";
                    FileHelperService.EnsureDirectoryExists(folder);
                    Quicklaunch.Properties.Settings.Default.folder = folder;
                    Quicklaunch.Properties.Settings.Default.Save();
                }


            


        }
    }
}


