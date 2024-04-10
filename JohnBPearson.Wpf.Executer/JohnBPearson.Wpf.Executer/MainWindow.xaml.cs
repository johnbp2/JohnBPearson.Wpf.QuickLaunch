using System.Diagnostics;
using System.Drawing.Printing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using JohnBPearson.Butlers.QuickLaunch;

namespace JohnBPearson.Wpf.Executer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<Tuple<Image, IExecutable>> cache = new List<Tuple<Image, IExecutable>>();

        
        private ImageService imageService = new ImageService();
        public MainWindow()
        {
            InitializeComponent();




        }

        private void Main_Loaded(object sender, RoutedEventArgs e)
        {

      
        }

        private void Main_Initialized(object sender, EventArgs e)
        {
            JohnBPearson.Butlers.QuickLaunch.Facade facade = new Butlers.QuickLaunch.Facade("./Quick Launch");
            var i = 100;
            var margin = 0;
            foreach(var shortcut in facade.Executables)
            {


                var image2 = new Image();


                image2.Width = 200;
                //  image2.Margin = new Thickness(margin, 0, 0, 0);
                //Uri myUri = new Uri("butler.ico", UriKind.RelativeOrAbsolute);
                //var decoder2 = new IconBitmapDecoder(myUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                //using(shortcut.Icon) {

                // BitmapSource bitmapSource2 = imageService.ImageSourceFromIcon(shortcut.Icon);//decoder2.Frames[0];
                var bmi = imageService.IconToBitmapImage(shortcut.Icon);
                // bitmapSource2.Freeze();
                image2.BeginInit();
                image2.Source = bmi;
                image2.EndInit();
                image2.Name = $"image{i}";
                image2.MouseDown += new MouseButtonEventHandler(Mouse_Down);
                cache.Add(new Tuple<Image, IExecutable>(image2, shortcut));
               //image.BeginInit();
               // image.Source = bmi;
               // image.EndInit();

                this.stack1.Children.Add(image2);
                //  }
                i++;
                margin = margin + 300;
            }

            
        }


        private void Mouse_Down(object sender, MouseEventArgs e)
        {
            foreach(var item in this.cache)
            {
                if(item.Item1.Name == ((Image)sender).Name)
                {
             var test =System.IO.File.ReadAllText(item.Item2.FullPath);
                    Debug.WriteLine(test);
                //Process.Start(item.Item2.FullPath);
                }
            }
        }
    }



}
