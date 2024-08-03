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
using System.Windows.Shapes;

namespace JohnBPearson.Wpf.Executer
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {

        private string _folder = string.Empty;
      

        private void button_Click(object sender, RoutedEventArgs e)
        {
           
            Microsoft.Win32.OpenFolderDialog dialog = new();

            dialog.Multiselect = false;
            dialog.Title = "Select a folder";

            // Show open foa    q   q   lder dialog box
            bool? result = dialog.ShowDialog();

            // Process open folder dialog box results
            if(result == true)
            {
                // Get the selected folder
                folder.Text = dialog.FolderName;
                //Properties.Settings.Default.folder = folder.Text;
                //Properties.Settings.Default.Save(); 
                this._folder = dialog.SafeFolderName;
            }
           
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
          
           
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            bool ontop = false;
            if(this.onTopYes.IsChecked != null)
            {
                ontop = this.onTopYes.IsChecked.Value;
            }
            Properties.Settings.Default.alwaysOnTop = ontop;
            Properties.Settings.Default.folder = folder.Text;
            Properties.Settings.Default.Save();
            this.Close();
                
                }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void onTopNo_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void SettingsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            folder.Text = Properties.Settings.Default.folder;
            if (Properties.Settings.Default.alwaysOnTop)
            {
                this.onTopYes.IsChecked = true;
            }
            else
            {
                this.onTopNo.IsChecked = true;
            }
        }
    }
}
