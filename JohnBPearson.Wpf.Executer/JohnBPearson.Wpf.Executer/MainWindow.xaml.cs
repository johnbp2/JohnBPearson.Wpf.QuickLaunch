using System.Configuration;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Reflection.Metadata;
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
using System.Runtime.InteropServices;
using System.Windows.Media.Animation;
using Windows.Devices.Scanners;

namespace JohnBPearson.Wpf.Executer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(2);
        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 SWP_SHOWWINDOW = 0x0040;
        const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;
        const UInt32 NOTOPMOST_FLAGS = SWP_SHOWWINDOW;


        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        [DllImport("user32.dll", EntryPoint = "GetWindowLong", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindowLong32(HandleRef hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindowLongPtr64(HandleRef hWnd, int nIndex);
        private List<ViewModels.AnimatedFileSystemObject> cache = new List<ViewModels.AnimatedFileSystemObject>();


        private ImageService imageService = new ImageService();


        private void Main_Loaded(object sender, RoutedEventArgs e)
        {
            setOnTop();


        }
        private const int iamageWidth = 32;
        private void Main_Initialized(object sender, EventArgs e)
        {
#if DEBUG
            this.implementAnimatedImages();
#endif

#if !DEBUG
            displayLinks();
#endif
            //   buildAnimatedImagesExample();
        }
        private void setOnTop()
        {
            var wih = new System.Windows.Interop.WindowInteropHelper(this);
            var hWnd = wih.Handle;
            if (Properties.Settings.Default.alwaysOnTop)
            {

                SetWindowPos(hWnd, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
            }
            else
            {
                // GetWindowLong32(hWnd, WS_OVERLAPPEDWINDOW)
                //if(GetWindowLong32(hWnd, GWL_EXSTYLE) & WS_EX_TOPMOST)
                //    hWnd. = HWND_NOTOPMOST;

                SetWindowPos(hWnd, (IntPtr)(-2), 0, 0, 0, 0, SWP_NOSIZE);
            }
        }
        private void displayLinks()
        {
            Facade facade = new Butlers.QuickLaunchCore.Facade(Properties.Settings.Default.folder);
            var i = 1;
            var margin = 0;
            var width = 0;

            foreach (var fileSystemObject in facade.FileSystemObjects)
            {

                if (fileSystemObject.Type != Extension.ini)
                {
                    var image2 = new Image();


                    image2.Width = iamageWidth;
                    width = width + iamageWidth + 10;

                    var bmi = imageService.IconToBitmapImage(fileSystemObject.Icon);
                    // bitmapSource2.Freeze();
                    image2.BeginInit();
                    image2.Source = bmi;
                    image2.EndInit();
                    image2.Name = $"image{i}";
                    image2.MouseDown += new MouseButtonEventHandler(Mouse_Down);
                    image2.Margin = new Thickness(0, 0, 10, 0);
                    cache.Add(new ViewModels.AnimatedFileSystemObject(fileSystemObject, new ScaleTransform(), image2));
                    //image.BeginInit();
                    // image.Source = bmi;
                    // image.EndInit();
                    image2.ToolTip = fileSystemObject.Name;
                    this.stack1.Children.Add(image2);
                    //  }
                    i++;
                    //   margin = margin + 300;
                }
                // stack1.MaxWidth = width;
                //   Main.Width = width;

                //  this.Width = width;
            }

        }

        private void Mouse_Down(object sender, MouseEventArgs e)
        {
            foreach (var item in this.cache)
            {
                if (item.FileSystemObjectBase.Name == ((Image)sender).Name)
                {
                    //var test =System.IO.file.ReadAllText(item.Item2.FullPath);
                    //      Debug.WriteLine(test);
                    //Process.Start(item.Item2.FullPath);
                    item.FileSystemObjectBase.Run();
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var settings = new Settings();
            settings.Owner = this;
            settings.ShowDialog();
            this.displayLinks();
            setOnTop();

        }
        private Storyboard? _mystoryboard = null;
      //  private ScaleTransform scaleTransform = null;// new ScaleTransform(1, 1);
        private void implementAnimatedImages()
        {
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
            Facade facade = new Butlers.QuickLaunchCore.Facade(Properties.Settings.Default.folder);
            var i = 100;
            var margin = 0;
            var width = 0;

            foreach (var fileSystemObject in facade.FileSystemObjects)
            {

                if (fileSystemObject.Type != Extension.ini)
                {
                    Image image2 = transpileIcon(i, ref width, fileSystemObject);

                    image2.MouseDown += new MouseButtonEventHandler(Mouse_Down);
                    image2.Margin = new Thickness(0, 0, 10, 0);
                    cache.Add(new ViewModels.AnimatedFileSystemObject(fileSystemObject, new ScaleTransform(), image2));

                    // image2.ToolTip = fileSystemObject.Name;


                    this.RegisterName(image2.Name, image2);



                    image2.MouseEnter += new MouseEventHandler(Image2_MouseEnter);

                    image2.MouseLeave += new MouseEventHandler(Image2_MouseLeave);




                    this.stack1.Children.Add(image2);

                    i++;

                }

            }

        }
        private const int dynamicMarginAdditive = 30;
        private void Image2_MouseLeave(object sender, MouseEventArgs e)
        {
            var image = (Image)sender;
            if (image != null)
            {
               
               
            
                
                var temp = image.RenderTransform as ScaleTransform;
                if (temp != null)
                {
                    temp.ScaleX = 1;
                    temp.ScaleY = 1;
                }
                image.Margin = new Thickness(0,0,10,0);
                    
                    
                    
                 //   Debug.WriteLine(string.Concat([this.ToString()," ", image.Margin.Right.ToString(), curr.Right.ToString()," - - - ", (currentMargine - dynamicMarginAdditive).ToString()]));
            }
        }
        private double currentMargine = 0;

        void Image2_MouseEnter(object sender, MouseEventArgs e)
        {

            var image = (Image)sender;
            if (image != null)
            {
                var cur = image.Margin;
              
                    cur.Right = cur.Right + dynamicMarginAdditive;
                
                this.currentMargine = cur.Right;
                image.Margin = cur;
               
                if ((image.RenderTransform is ScaleTransform))
                {

                    var scaleTransform = (ScaleTransform)image.RenderTransform;
                    scaleTransform.ScaleX = 2;
                    scaleTransform.ScaleY = 2;
                }
                else
                {
                    var scaleTransform = new ScaleTransform(1, 1);
                    Storyboard.SetTargetName(scaleTransform, image.Name);

                    Storyboard.SetTargetProperty(scaleTransform, new PropertyPath(ScaleTransform.ScaleXProperty));
                    Storyboard.SetTargetProperty(scaleTransform, new PropertyPath(ScaleTransform.ScaleYProperty));
                   // this._mystoryboard = new Storyboard();

                    image.RenderTransform = scaleTransform;
                    scaleTransform.ScaleX = 2;
                    scaleTransform.ScaleY = 2;
                }
                //if (image != null)
                //{

                //    foreach (var item in this.cache)
                //    {
                //        if (item.FileSystemObjectBase != null && item.FileSystemObjectBase.Name == image.Name)
                //        {
                //            ///            item.scaleTransform.ScaleX = 2;
                //            //         item.scaleTransform.ScaleY = 2;
                //        }


                //    }

                //}

            }
        }

        Image transpileIcon(int i, ref int width, IFileSystemObjectBase? fileSystemObject)
        {
            var image2 = new Image();
            image2.Name = $"image{i}";
            this.RegisterName(image2.Name, image2);

            image2.Width = iamageWidth;
            width = width + iamageWidth + 10;

            var bmi = imageService.IconToBitmapImage(fileSystemObject.Icon);

            image2.BeginInit();
            image2.Source = bmi;
            image2.EndInit();
            return image2;
        }



    }
}