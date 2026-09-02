#define IMAGETEST
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Quicklaunch.Controls;
using JohnBPearson.FileObjects;
using JohnBPearson.FileObjects.FileMetaDataModel;

namespace Quicklaunch
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<ImageControl> cache = new List<ImageControl>();



        const int imageWidth = 32;
        private const double scaleTransformFactor = 1.4;

        [Obsolete]
        double currentMargine = 0;

        #region events
        void Main_Loaded(object sender, RoutedEventArgs e)
        {
            Services.UnmanagedService.SetOnTop(this);
            var drawingColor = Properties.Settings.Default.bgColor;
          
          
            this.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(drawingColor.R, drawingColor.G, drawingColor.B));
         
            this.Background.Opacity = Properties.Settings.Default.opacity;

        }


        void Main_Initialized(object sender, EventArgs e)
        {

            this.implementAnimatedImages();


        }


        void Mouse_Down(object sender, MouseEventArgs e)
        {
            foreach(var item in this.cache)
            {
                if(item.Name == ((ImageControl)sender).Name)
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
        void Image2_MouseLeave(object sender, MouseEventArgs e)
        {
            var image = (ImageControl)sender;
            if(image != null)
            {


                ScaleTransform? temp = null;

#if IMAGETEST
                temp = image.LayoutTransform as ScaleTransform;
#else
                 temp = image.RenderTransform as ScaleTransform;
#endif
                if(temp != null)
                {

                    temp.ScaleX = 1;
                    temp.ScaleY = 1;
                }
                else
                {
                    throw new Exception("ScaleTransform is null");
                }
                // image.Margin = new Thickness(10, 0, 10, 0);
                this.defaultImageMargins(ref image);



                //   Debug.WriteLine(string.Concat([this.ToString()," ", image.Margin.Right.ToString(), curr.Right.ToString()," - - - ", (currentMargine - dynamicMarginAdditive).ToString()]));
            }
        }


        void Image2_MouseEnter(object sender, MouseEventArgs e)
        {

            var image = (Controls.ImageControl)sender;
            if(image != null)
            {

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

                    throw new Exception(Name + " is not a ScaleTransform");


                    image.scaleTransform.ScaleX = scaleTransformFactor;
                    image.scaleTransform.ScaleX = scaleTransformFactor;
                }
                this.defaultImageMargins(ref image);

            }
        }

        private void Main_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
                Main.DragMove();
        }


        private void MenuItemDockLeft_Click(object sender, RoutedEventArgs e)
        {
            this.DockWindow(Dock.Left);
        }

        private void MenuItemDockRight_Click(object sender, RoutedEventArgs e)
        {
            this.DockWindow(Dock.Right);
        }
        #endregion
        private void DockWindow(Dock position)
        {
            double screenWidth = SystemParameters.WorkArea.Width;
            double screenHeight = SystemParameters.WorkArea.Height;
            double screenTop = SystemParameters.WorkArea.Top;
            double screenLeft = SystemParameters.WorkArea.Left;
            this.WindowState = WindowState.Normal;
            this.Top = screenTop;
            if(position == Dock.Left)
            {
              
                
                this.Left = screenLeft;
                
            }
            else if(position == Dock.Right)
            {
                
                
                this.Left = screenLeft + screenWidth - this.Width;
                
            }
            this.Height = screenHeight;
        }
        void implementAnimatedImages()
        {
            stack1.Children.Clear();
            NameScope.SetNameScope(this, new NameScope());


           // stack1.HorizontalAlignment = HorizontalAlignment.Left;
            if(Properties.Settings.Default.horizontalOrientation)
            {
                stack1.Orientation = Orientation.Horizontal;
            }
            else
            {
                stack1.Orientation = Orientation.Vertical;
            }

         
            Facade.DirectoryPath = Properties.Settings.Default.folder;
            var i = 100;

            double width = 0.00;

            foreach(var fileSystemObject in Facade.FileSystemObjects)
            {

                if(fileSystemObject.Type != FileExtensionEnum.bat)
                {
                    Controls.ImageControl image = convertIconToBitmap(i, ref width, fileSystemObject);

                    image.MouseDown += new MouseButtonEventHandler(Mouse_Down);
                    this.defaultImageMargins(ref image);
                    cache.Add(image);


                    this.RegisterName(image.Name, image);



                    image.MouseEnter += new MouseEventHandler(Image2_MouseEnter);

                    image.MouseLeave += new MouseEventHandler(Image2_MouseLeave);




                    this.stack1.Children.Add(image);
                    Storyboard.SetTargetName(image.scaleTransform, image.Name);

                    Storyboard.SetTargetProperty(image.scaleTransform, new PropertyPath(ScaleTransform.ScaleXProperty));
                    Storyboard.SetTargetProperty(image.scaleTransform, new PropertyPath(ScaleTransform.ScaleYProperty));

#if IMAGETEST
                    image.LayoutTransform = image.scaleTransform;
#else
                    image.RenderTransform = image.scaleTransform;
#endif
                    i++;

                }

            }
            if(Properties.Settings.Default.horizontalOrientation)
            {
                this.Width = width;
                this.stack1.Width = width;
                this.stack1.Height = 60;
                this.gridMain.ColumnDefinitions[0].Width = new GridLength(width);
                this.Height = 60;
                this.gridMain.RowDefinitions[0].Height = new GridLength(60);
                this.gridMain.Width = width;
                this.gridMain.Height = 60;
            }
            else
            {
                this.Height = width;
                this.stack1.Height = width;
                this.stack1.Width = 60;
                this.gridMain.RowDefinitions[0].Height = new GridLength(width);
                this.gridMain.Height = width;
                this.gridMain.Width = 60;
                this.Width = 60;
                this.gridMain.ColumnDefinitions[0].Width = new GridLength(60);
            }
        }
        private void defaultImageMargins(ref Controls.ImageControl image)
        {
            if(stack1.Orientation == Orientation.Horizontal)
            {
                image.Margin = new Thickness(10, 0, 10, 0);
            }
            else
            {
                image.Margin = new Thickness(0, 10, 0, 10);
            }
        }

        private Controls.ImageControl convertIconToBitmap(int i, ref double width, IFileSystemObjectBase fileSystemObject)
        {
            var image2 = new Controls.ImageControl(new ScaleTransform(1, 1), fileSystemObject);
            image2.Name = $"image{i}";


            image2.Width = imageWidth;
            width = width + imageWidth + 20;

            var bmi = Services.ImageService.IconToBitmapImage(fileSystemObject.Icon);

            image2.BeginInit();
            image2.Source = bmi;
            image2.EndInit();
            return image2;
        }


    }
}