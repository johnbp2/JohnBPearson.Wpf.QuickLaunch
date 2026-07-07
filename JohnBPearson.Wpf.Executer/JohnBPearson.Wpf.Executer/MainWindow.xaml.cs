// #define IMAGETEST
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using JohnBPearson.Wpf.QuickLaunchCore;
using JohnBPearson.Wpf.QuickLaunchCore.FileMetaDataModel;

namespace JohnBPearson.Wpf.Executer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
    
      private  List<ViewModels.AnimatedFileSystemObject> cache = new List<ViewModels.AnimatedFileSystemObject>();


      private  ImageService imageService = new ImageService();
       private const int dynamicMarginAdditive = 30;
        const int imageWidth = 32;
        private const double scaleTransformFactor = 1.4;

        [Obsolete]
        double currentMargine = 0;
       
        void Main_Loaded(object sender, RoutedEventArgs e)
        {
            Unmanaged.SetOnTop(this);


        }
       

        void Main_Initialized(object sender, EventArgs e)
        {
#if DEBUG
            this.implementAnimatedImages();
#endif

#if !DEBUG
             this.implementAnimatedImages();
#endif
            //   buildAnimatedImagesExample();
        }


            void Mouse_Down(object sender, MouseEventArgs e)
            {
                foreach (var item in this.cache)
                {
                    if (item.Image.Name == ((Image)sender).Name)
                    {
                        //var test =System.IO.file.ReadAllText(item.Item2.FullPath);
                        //      Debug.WriteLine(test);
                        //Process.Start(item.Item2.FullPath);
                        item.FileSystemObjectBase.Run();
                        break;
                    }
                }
            }

            void MenuItemSettings_Click(object sender, RoutedEventArgs e)
            {
                var settings = new Settings();
                settings.Owner = this;
                settings.ShowInTaskbar = true;
                settings.ShowDialog();
                this.implementAnimatedImages();



        }

        void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private Storyboard? _mystoryboard = null;
      //  ScaleTransform scaleTransform = null;// new ScaleTransform(1, 1);
        void implementAnimatedImages()
        {
            stack1.Children.Clear();
            NameScope.SetNameScope(this, new NameScope());

            //this.WindowTitle = "Animate Properties using Storyboards";
            // StackPanel stack1 = new StackPanel();
            //  stack1.MinWidth = 500;
            // stack1.Margin = new Thickness(30);
            stack1.HorizontalAlignment = HorizontalAlignment.Left;
            //   TextBlock myTextBlock = new TextBlock();
            //  myTextBlock.Text = "Storyboard Animation Example";
            // stack1.Children.Add(myTextBlock);

            //
            // Create and animate the first image.
            //

            // Create a images.
            Facade facade = new Wpf.QuickLaunchCore.Facade(Properties.Settings.Default.folder);
            var i = 100;
           
            double width = 0.00;

            foreach (var fileSystemObject in facade.FileSystemObjects)
            {

                if (fileSystemObject.Type != FileExtensionEnum.ini)
                {
                    Controls.Image image = transpileIcon(i, ref width, fileSystemObject);

                    image.MouseDown += new MouseButtonEventHandler(Mouse_Down);
                    this.defaultImageMargins(ref image);
                    cache.Add(new ViewModels.AnimatedFileSystemObject(fileSystemObject, new ScaleTransform(), image));

                    
                    this.RegisterName(image.Name, image);



                    image.MouseEnter += new MouseEventHandler(Image2_MouseEnter);

                    image.MouseLeave += new MouseEventHandler(Image2_MouseLeave);




                    this.stack1.Children.Add(image);

                    i++;

                }

            }
            this.Width = width;
            this.stack1.Width = width;
            this.gridMain.ColumnDefinitions[0].Width = new GridLength(width);
            this.gridMain.Width = width;
        }
        private void defaultImageMargins(ref Controls.Image image)
        {
            image.Margin = new Thickness(10, 0, 10, 0);
        }

        private Controls.Image transpileIcon(int i, ref double width, IFileSystemObjectBase? fileSystemObject)
        {
            var image2 = new Controls.Image(new ScaleTransform(1, 1), fileSystemObject);
            image2.Name = $"image{i}";


            image2.Width = imageWidth;
            width = width + imageWidth + 20;

            var bmi = imageService.IconToBitmapImage(fileSystemObject.Icon);

            image2.BeginInit();
            image2.Source = bmi;
            image2.EndInit();
            return image2;
        }
        void Image2_MouseLeave(object sender, MouseEventArgs e)
        {
            var image = (Image)sender;
            if (image != null)
            {


                ScaleTransform? temp = null;

#if IMAGETEST
                temp = image.LayoutTransform as ScaleTransform;
#else
                 temp = image.RenderTransform as ScaleTransform;
#endif
                if (temp != null)
                {
                    temp.ScaleX = 1;
                    temp.ScaleY = 1;
                }
                image.Margin = new Thickness(10,0,10,0);
                    
                    
                    
                 //   Debug.WriteLine(string.Concat([this.ToString()," ", image.Margin.Right.ToString(), curr.Right.ToString()," - - - ", (currentMargine - dynamicMarginAdditive).ToString()]));
            }
        }


        void Image2_MouseEnter(object sender, MouseEventArgs e)
        {

            var image = (Controls.Image)sender;
            if (image != null)
            {
                //var cur = image.Margin;

                //cur.Right = cur.Right + dynamicMarginAdditive;

                //this.currentMargine = cur.Right;
                //image.Margin = cur;

                if((image.RenderTransform is ScaleTransform))
                {

                    var scaleTransform = (ScaleTransform)image.RenderTransform;
                    scaleTransform.ScaleX = scaleTransformFactor;
                    scaleTransform.ScaleY = scaleTransformFactor;
                }
                else if(image.LayoutTransform is ScaleTransform)
                {
                    var scaleTransform = (ScaleTransform)image.LayoutTransform;
                    scaleTransform.ScaleX = scaleTransformFactor;
                    scaleTransform.ScaleY = scaleTransformFactor;
                }
                else
                {
                  //  var scaleTransform = new ScaleTransform(1, 1);

                    Storyboard.SetTargetName(image.scaleTransform, image.Name);

                    Storyboard.SetTargetProperty(image.scaleTransform, new PropertyPath(ScaleTransform.ScaleXProperty));
                    Storyboard.SetTargetProperty(image.scaleTransform, new PropertyPath(ScaleTransform.ScaleYProperty));

#if IMAGETEST
                    image.LayoutTransform = image.scaleTransform;
#else
                    image.RenderTransform = image.scaleTransform;
#endif
                    image.scaleTransform.ScaleX = scaleTransformFactor;
                    image.scaleTransform.ScaleX = scaleTransformFactor;
                }
                this.defaultImageMargins(ref image);

            }
        }

     



    }
}