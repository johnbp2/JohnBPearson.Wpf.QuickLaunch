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
using JohnBPearson.Butlers.QuickLaunchCore;
using JohnBPearson.Butlers.QuickLaunchCore.FileMetaDataModel;


namespace JohnBPearson.Wpf.Executer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<Tuple<Image, IFileSystemObjectBase>> cache = new List<Tuple<Image, IFileSystemObjectBase>>();

        
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
           
            Facade facade = new Butlers.QuickLaunchCore.Facade("./Quick Launch");
            var i = 100;
            var margin = 0;
            foreach(var fileSystemOnject in facade.FileSystemObjects)
            {

                if(fileSystemOnject.Type != Extention.ini)
                {
                    var image2 = new Image();


                image2.Width = 200;
              

                    var bmi = imageService.IconToBitmapImage(fileSystemOnject.Icon);
                    // bitmapSource2.Freeze();
                    image2.BeginInit();
                    image2.Source = bmi;
                    image2.EndInit();
                    image2.Name = $"image{i}";
                    image2.MouseDown += new MouseButtonEventHandler(Mouse_Down);
                    cache.Add(new Tuple<Image, IFileSystemObjectBase>(image2, fileSystemOnject));
                    //image.BeginInit();
                    // image.Source = bmi;
                    // image.EndInit();

                    this.stack1.Children.Add(image2);
                    //  }
                    i++;
                    margin = margin + 300;
                }
            }
            
        }


        private void Mouse_Down(object sender, MouseEventArgs e)
        {
            foreach(var item in this.cache)
            {
                if(item.Item1.Name == ((Image)sender).Name)
                {
                    //var test =System.IO.file.ReadAllText(item.Item2.FullPath);
                    //      Debug.WriteLine(test);
                    //Process.Start(item.Item2.FullPath);
                    item.Item2.Run();
                }
            }
        }
    }



}
