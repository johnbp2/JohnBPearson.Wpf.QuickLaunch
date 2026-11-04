using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Quicklaunch.Views
{
    public  class SettingsPresenter : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public  SettingsPresenter()
        {
            //this.AlwaysOnTop = Properties.Settings.Default.alwaysOnTop;
            //this.OrientationHorizontal = Properties.Settings.Default.horizontalOrientation;
            //this.SecondaryDisplay = Properties.Settings.Default.displayOnSecondary;
            //this.Opacity = Properties.Settings.Default.opacity;
            //this.BgColor = Properties.Settings.Default.bgColor;
        }

        private void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private bool alwaysOnTop;

        public bool AlwaysOnTop
        {
            get { return Properties.Settings.Default.alwaysOnTop; }
            set {
                Properties.Settings.Default.alwaysOnTop = value;
                this.OnPropertyChanged();
            }
        }
        
        //private bool orientationHorizontal;

        public bool OrientationHorizontal
        {
            get { return Properties.Settings.Default.horizontalOrientation; }
            set { 
                Properties.Settings.Default.horizontalOrientation = value;
                this.OnPropertyChanged();
            }
        }

        //private bool secondaryDisplay;

        public bool SecondaryDisplay
        {
            get { return Properties.Settings.Default.displayOnSecondary; }
            set { 
                Properties.Settings.Default.displayOnSecondary = value;
                this.OnPropertyChanged();
             }
        }

        //private double opacity;

        public double Opacity
        {
            get { return Properties.Settings.Default.opacity; }
            set { //opacity = value;
                Properties.Settings.Default.opacity = value;
                this.OnPropertyChanged();
            }
        }

      //  private System.Drawing.Color bgColor;

        public System.Drawing.Color BgColor
        {
            get { return Properties.Settings.Default.bgColor; }
            set { 
                Properties.Settings.Default.bgColor = value;
                this.OnPropertyChanged();

            }
        }

        public void SaveSettings()
        {
            Properties.Settings.Default.Save();
        }

        public  static class PropertyNames{
            public static string AlwaysOnTop => nameof(AlwaysOnTop);
            public static string OrientationHorizontal => nameof(OrientationHorizontal);
            public static string SecondaryDisplay => nameof(SecondaryDisplay);
            public static string Opacity => nameof(Opacity);
            public static string BgColor => nameof(BgColor);


        }
    }
}
