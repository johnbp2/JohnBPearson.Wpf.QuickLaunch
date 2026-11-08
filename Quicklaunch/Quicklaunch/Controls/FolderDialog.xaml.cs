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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Quicklaunch.Controls
{
    /// <summary>
    /// Interaction logic for FolderDialog.xaml
    /// </summary>
    public partial class FolderDialog : System.Windows.Controls.UserControl
    {
        public FolderDialog()
        {
            InitializeComponent();
        }
        public string HeaderText
        {
            get;
            set;
        }
        private string _selectedFolder = "";
        public string SelectedFolder
        {
            get
            {
            return _selectedFolder;
            }
            set
            {
            _selectedFolder = value;
                tbFolder.Text = _selectedFolder;
            }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Background = new SolidColorBrush();
            this.Background.Opacity = 0;
            if(!string.IsNullOrEmpty(HeaderText))
            {
                this.gbFolder.Header = HeaderText;
            }

        }

        private void browse_Click(object sender, RoutedEventArgs e)
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
                //tbFolder.Text = dialog.FolderName;
                //Properties.Settings.Default.folder = folder.Text;
                //Properties.Settings.Default.Save(); 
                this.SelectedFolder = dialog.SafeFolderName;
            }
        }
    }
}
