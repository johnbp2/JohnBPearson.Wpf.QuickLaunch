using Quicklaunch.Services;
using System.Windows;
using System.Windows.Controls;
using Windows.Gaming.Input.ForceFeedback;

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
                if (System.IO.Path.IsPathRooted(Quicklaunch.Properties.Settings.Default.folder))
                {
                    folder = Quicklaunch.Properties.Settings.Default.folder;
                }
                FileHelperService.EnsureDirectoryExists(folder);
                Quicklaunch.Properties.Settings.Default.folder = folder;
                Quicklaunch.Properties.Settings.Default.Save();

                // bool prevInstance;
                //_ = new System.Threading.Mutex(true, "Application Name", out prevInstance);


            }
        }
    }

}
