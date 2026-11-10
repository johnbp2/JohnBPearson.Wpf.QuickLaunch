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
using Microsoft.Win32;
using Windows.Networking.NetworkOperators;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Quicklaunch.Controls
{


    public enum FileSystemType
    {
        File,
        Folder
    }
    /// <summary>
    /// Interaction logic for FolderDialog.xaml
    /// </summary>
    public partial class FolderDialog : System.Windows.Controls.UserControl
    {
        public FolderDialog()
        {
            HeaderText = "Select a folder";
            InitializeComponent();
        }
        public string HeaderText
        {
            get;
            set;
        }
        private string _selectedPath = "";
        public string SelectedPath
        {
            get
            {
                return _selectedPath;
            }
            set
            {
                _selectedPath = value;
                tbFolder.Text = _selectedPath;
            }
        }
        public FileSystemType FileSystemType
        {
            get;
            set;
        } = FileSystemType.Folder;
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

            bool? result = false;
            CommonItemDialog? dialog = null;

            if(FileSystemType == FileSystemType.File)
            {
                var fileDialog = new Microsoft.Win32.OpenFileDialog
                {
                    Multiselect = false,
                    Title = "Select a folder",
                    InitialDirectory = System.IO.Path.GetDirectoryName(SelectedPath)
                };
                // Show open folder dialog box
                result = fileDialog.ShowDialog();
                dialog = fileDialog;

            }
            else
            {
                var folderDialog = new Microsoft.Win32.OpenFolderDialog
                {
                    Multiselect = false,
                    Title = "Select a folder",
                    InitialDirectory = SelectedPath
                };
                result = folderDialog.ShowDialog();
                dialog = folderDialog;

            }

            if(result is not null && dialog is not null && result == true)
            {
                this.checkResult(dialog);
            }

            // Process open folder dialog box results
            //if (result == true && dialog is not null)
            //{
            //    if (FileSystemType == FileSystemType.File)
            //    {
            //        // Get the selected file
            //        this.SelectedPath = (dialog as Microsoft.Win32.OpenFileDialog).;
            //    }
            //    else
            //    {
            //        // Get the selected folder
            //        this.SelectedPath = (dialog as Microsoft.Win32.OpenFolderDialog).SafeFolderName;
            //}
        }

        private void checkResult(Microsoft.Win32.CommonDialog dialog)
        {
            if(dialog is Microsoft.Win32.OpenFileDialog fileDialog)
            {
                // Get the selected file
                this.SelectedPath = fileDialog.FileName;
            }
            else if(dialog is Microsoft.Win32.OpenFolderDialog folderDialog)
            {
                // Get the selected folder
                this.SelectedPath = folderDialog.FolderName;
            }
        }
    }
}
