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

namespace Quicklaunch
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {

        private string _folder = string.Empty;
        internal MainWindow main;
        private void pick_Color(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog dialog = new();

            var result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                var color = dialog.Color;
                Properties.Settings.Default.bgColor = color;
            }
            displayColor();
            
        }
        
        private void button_Click(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFolderDialog dialog = new();

            dialog.Multiselect = false;
            dialog.Title = "Select a folder";

            // Show open foa    q   q   lder dialog box
            bool? result = dialog.ShowDialog();

            // Process open folder dialog box results
            if (result == true)
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
            if (this.onTopYes.IsChecked != null)
            {
                ontop = this.onTopYes.IsChecked.Value;
            }
            bool horiz = false;
            if (this.orientationHorizontal.IsChecked != null)
            {
                horiz = this.orientationHorizontal.IsChecked.Value;
            }
            Properties.Settings.Default.horizontalOrientation = horiz;
            Properties.Settings.Default.alwaysOnTop = ontop;
            Properties.Settings.Default.folder = folder.Text;
            Properties.Settings.Default.opacity = this.opacitySlider.Value;
            Properties.Settings.Default.displayOnSecondary = this.secondaryDisplay.IsChecked ?? false;

            Properties.Settings.Default.Save();

            main.SetBGColor(Properties.Settings.Default.bgColor);
            this.Close();

        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void onTopNo_Checked(object sender, RoutedEventArgs e)
        {

        }
        public Settings()
        {
            InitializeComponent();
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

            if (Properties.Settings.Default.horizontalOrientation)
            {
                this.orientationHorizontal.IsChecked = true;
            }
            else
            {
                this.orientationVertical.IsChecked = true;
            }
            if (Properties.Settings.Default.displayOnSecondary)
            {
                this.secondaryDisplay.IsChecked = true;
            }
            else
            {
                this.primaryDisplay.IsChecked = true;
            }
            this.opacitySlider.Value = Properties.Settings.Default.opacity;
            setOpacityLabel(Properties.Settings.Default.opacity);
            displayColor();
        }

        private void displayColor()
        {
            var mediaColor = System.Windows.Media.Color.FromRgb(Properties.Settings.Default.bgColor.R, Properties.Settings.Default.bgColor.G, Properties.Settings.Default.bgColor.B);
            colorRectangle.Fill = new SolidColorBrush(mediaColor);
        }

        private void opacitySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            setOpacityLabel(e.NewValue);
        }

        private void setOpacityLabel(double value)
        {
            if (labelOpacity != null)
            {


                labelOpacity.Content = $"Opacity: {value.ToString("0.00")}%";
            }
        }
    }
}
