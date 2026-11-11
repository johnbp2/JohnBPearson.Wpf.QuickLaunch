#define TESTANIMATION
using JohnBPearson.FileObjects;
using JohnBPearson.FileObjects.Model;
using Quicklaunch.Controls;
using Quicklaunch.Services;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Input = System.Windows.Input;

namespace Quicklaunch.Controls
{
    /// <summary>
    /// Interaction logic for Toolbar.xaml
    /// </summary>
    public partial class Toolbar : System.Windows.Controls.UserControl
    {
        private List<ImageControl> cache = new List<ImageControl>();
        const int imageWidth = 32;
        private const double scaleTransformFactor = 1.4;
        private double toolbarX = 0;
        private FileHelperService _fileService = new FileHelperService();

        public double X
        {

            get
            {
                return toolbarX;
            }
            private set
            {
                toolbarX = value;
            }
        }
        private double toolbarY = 0;
        public double Y
        {
            get
            {
                return toolbarY;
            }
            private set
            {
                toolbarY = value;
            }
        }
        public Toolbar()
        {
            InitializeComponent();
        }

        private void Toolbar_Initialized(object sender, EventArgs e)
        {
            this.populateToolbar();
            _fileService.WatchDirectory(Properties.Settings.Default.folder);
            _fileService.RefreshNeeded += (s, e) =>
            {
                this.Dispatcher.Invoke(() =>
                {
                  //  Facade.RefreshFileSystemObjects();
                    this.populateToolbar();
                });
            };
        }

        void ImageControlMouse_Down(object sender, Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {

                foreach (var item in this.cache)
                {
                    if (item.Name == ((ImageControl)sender).Name)
                    {
                        //var test =System.IO.file.ReadAllText(item.Item2.FullPath);
                        //      Debug.WriteLine(test);
                        //Process.Start(item.Item2.FullPath);2
                        item.FileSystemObject.Run();
                        break;
                    }
                }
            }
        }
        void ImageControl_MouseLeave(object sender, Input.MouseEventArgs e)
        {
            var image = (ImageControl)sender;
#if TESTANIMATION
            image.StopBounceAnimation();
#else
            if (image != null)
            {

                image.scaleDown();
                // image.Margin = new Thickness(10, 0, 10, 0);
                this.defaultImageMargins(ref image);



                //   Debug.WriteLine(string.Concat([this.ToString()," ", image.Margin.Right.ToString(), curr.Right.ToString()," - - - ", (currentMargine - dynamicMarginAdditive).ToString()]));
            }
#endif
        }


        void ImageControl_MouseEnter(object sender, Input.MouseEventArgs e)
        {

            var image = (Controls.ImageControl)sender;
#if TESTANIMATION
            image.AnimateBounce();

#else



            if (image != null)
            {

              image.scaleUp();
                this.defaultImageMargins(ref image);

            }
#endif
        }

        void populateToolbar()
        {
            toolbarPanel.Children.Clear();
            this.X = 0;
            NameScope.SetNameScope(this, new NameScope());


            // stack1.HorizontalAlignment = HorizontalAlignment.Left;
            if (Properties.Settings.Default.horizontalOrientation)
            {
                toolbarPanel.Orientation = System.Windows.Controls.Orientation.Horizontal;
            }
            else
            {
                toolbarPanel.Orientation = System.Windows.Controls.Orientation.Vertical;
            }


            //Facade.DirectoryPath = Properties.Settings.Default.folder;

            var i = 100;


            // TODO: [x] add tooltips

            foreach (var fileSystemObject in Facade.GetFileSystemObjects(Properties.Settings.Default.folder))
            {

                if (fileSystemObject.Type != FileExtensionEnum.bat)
                {

                    Controls.ImageControl image = createImageControl(i, fileSystemObject);

                    image.MouseDown += new MouseButtonEventHandler(ImageControlMouse_Down);

                    this.defaultImageMargins(ref image);
                    cache.Add(image);


                    this.RegisterName(image.Name, image);



                    image.MouseEnter += new Input.MouseEventHandler(ImageControl_MouseEnter);

                    image.MouseLeave += new Input.MouseEventHandler(ImageControl_MouseLeave);




                    this.toolbarPanel.Children.Add(image);
                    Storyboard.SetTargetName(image.scaleTransform, image.Name);

                    Storyboard.SetTargetProperty(image.scaleTransform, new PropertyPath(ScaleTransform.ScaleXProperty));
                    Storyboard.SetTargetProperty(image.scaleTransform, new PropertyPath(ScaleTransform.ScaleYProperty));


                    image.LayoutTransform = image.scaleTransform;


                    //if(Properties.Settings.Default.autoShade)
                    //{
                    //    image.Visibility = Visibility.Collapsed;
                    //}
                    i++;


                }

            }
            this.setWidths(X);
            this.setHeights(X);

        }
        // TODO: [x]refactor separate method for height.
        private void setWidths(double width)
        {

            // 60 horizontal height is always 60, vertical width is always 60.  The other dimension is variable based on the number of images and the image width.
            if (Properties.Settings.Default.horizontalOrientation)
            {
                this.Width = width;
                this.toolbarPanel.Width = width;
                // this.gridMain.ColumnDefinitions[0].Width = new GridLength(width);

                // this.gridMain.Width = width;

            }
            else
            {

                this.toolbarPanel.Width = 60;


                // this.gridMain.Width = 60;
                this.Width = 60;
                // this.gridMain.ColumnDefinitions[0].Width = new GridLength(60);
            }
        }
        private void setHeights(double height)
        {

            if (Properties.Settings.Default.horizontalOrientation)
            {
                this.toolbarPanel.Height = 60;

                this.Height = 60;
                // this.gridMain.RowDefinitions[0].Height = new GridLength(60);
                // this.gridMain.Height = 60;

            }
            else
            {
                this.Height = height;
                // this.gridMain.RowDefinitions[0].Height = new GridLength(height);
                this.toolbarPanel.Height = height;
                // this.gridMain.Height = height;

            }

        }
        private void defaultImageMargins(ref Controls.ImageControl image)
        {
            if (toolbarPanel.Orientation == System.Windows.Controls.Orientation.Horizontal)
            {
                image.Margin = new Thickness(10, 0, 10, 0);
            }
            else
            {
                image.Margin = new Thickness(0, 10, 0, 10);
            }
        }

        private Controls.ImageControl createImageControl(int i, IFileSystemObjectBase fileSystemObject)
        {
            var image2 = new Controls.ImageControl(new ScaleTransform(1, 1), fileSystemObject, fileSystemObject.Name);
            image2.Name = $"image{i}";


            image2.Width = imageWidth;
            X = X + imageWidth + 20;

            var bmi = Services.ImageService.IconToBitmapImage(fileSystemObject.Icon);

            image2.BeginInit();
            image2.Source = bmi;
            image2.EndInit();
            return image2;
        }
    }
}
