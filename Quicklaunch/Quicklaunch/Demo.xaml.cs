using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace Quicklaunch
{
    /// <summary>
    /// Interaction logic for Demo.xaml
    /// </summary>
    public partial class Demo : Window
    {
        TimeSpan time;
        private DispatcherTimer _timer;
      
        public Demo()
        {
            InitializeComponent();

            InitializeComponent();
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(.01);
            _timer.Tick += timer_Tick;
            _timer.Start();
            time = new TimeSpan(0, 0, 10);
            lblTime.Content = "10";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
       
            
        }
        void timer_Tick(object sender, EventArgs e)
        {
          time = time.Add(TimeSpan.FromSeconds(-.01));
            lblTime.Content = time.ToString(@"hh\:mm\:ss\.fff");
        }

        private class TimerSynch
        {
            internal static double ElapsedMillidseconds;
        }
    }
}
