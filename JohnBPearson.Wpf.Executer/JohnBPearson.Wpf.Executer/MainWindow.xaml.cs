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
        private List<Tuple<Image, IFileSystemObjectBase>> cache = new List<Tuple<Image, IFileSystemObjectBase>>();


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
            if(Properties.Settings.Default.alwaysOnTop)
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
            var i = 100;
            var margin = 0;
            var width = 0;

            foreach(var fileSystemObject in facade.FileSystemObjects)
            {

                if(fileSystemObject.Type != Extension.ini)
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
                    cache.Add(new Tuple<Image, IFileSystemObjectBase>(image2, fileSystemObject));
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var settings = new Settings();
            settings.Owner = this;
            settings.ShowDialog();
            this.displayLinks();
            setOnTop();

        }
        private Storyboard? _mystoryboard = null;
        private ScaleTransform scaleTransform = new ScaleTransform(1, 1);
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

            foreach(var fileSystemObject in facade.FileSystemObjects)
            {

                if(fileSystemObject.Type != Extension.ini)
                {
                    Image image2 = transpileIcon(i, ref width, fileSystemObject);

                    image2.MouseDown += new MouseButtonEventHandler(Mouse_Down);
                    image2.Margin = new Thickness(0, 0, 10, 0);
                    cache.Add(new Tuple<Image, IFileSystemObjectBase>(image2, fileSystemObject));

                    // image2.ToolTip = fileSystemObject.Name;


                    this.RegisterName(image2.Name, image2);
                   


                    DoubleAnimation myDoubleAnimation = new DoubleAnimation();

                    myDoubleAnimation.To = 3.0;
                    
                    myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(10));
                    myDoubleAnimation.AutoReverse = true;

                    Storyboard.SetTargetName(scaleTransform, image2.Name);
                    Storyboard.SetTargetProperty(scaleTransform, new PropertyPath(ScaleTransform.ScaleXProperty));
                    this._mystoryboard = new Storyboard();

                    image2.RenderTransform = scaleTransform;
                    this._mystoryboard.Children.Add(myDoubleAnimation);
                    image2.MouseEnter += new MouseEventHandler(Image2_MouseEnter);






                    this.stack1.Children.Add(image2);

                    i++;

                }

               // var stack2 = new StackPanel();
                //this.gridMain.

                foreach(var fso in facade.FileSystemObjects)
                {

                    if(fso.Type != Extension.ini)
                    {

                    }

                }
                //Button myWidthAnimatedButton = new Button();
                //myWidthAnimatedButton.Height = 30;
                //myWidthAnimatedButton.Width = 200;
                //myWidthAnimatedButton.HorizontalAlignment = HorizontalAlignment.Left;
                //myWidthAnimatedButton.Content = "A Button";

                // Set the Name of the button so that it can be referred
                // to in the storyboard that's created later.
                // The ID doesn't have to match the variable name;
                // it can be any unique identifier.
                // myWidthAnimatedButton.Name = "myWidthAnimatedButton";

                // Register the name with the page to which the button belongs.
                // this.RegisterName(myWidthAnimatedButton.Name, myWidthAnimatedButton);

                // Create a DoubleAnimation to animate the width of the button.
                //DoubleAnimation myDoubleAnimation = new DoubleAnimation();
                //myDoubleAnimation.From = 200;
                //myDoubleAnimation.To = 300;
                //myDoubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(3000));

                // Configure the animation to target the button's Width property.
                //Storyboard.SetTargetName(myDoubleAnimation, myWidthAnimatedButton.Name);
                //Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Button.WidthProperty));

                // Create a storyboard to contain the animation.
                //Storyboard myWidthAnimatedButtonStoryboard = new Storyboard();
                //myWidthAnimatedButtonStoryboard.Children.Add(myDoubleAnimation);

                // Animate the button width when it's clicked.


                //
                // Create and animate the second button.
                //

                // Create a second button.
                //Button myColorAnimatedButton = new Button();
                //myColorAnimatedButton.Height = 30;
                //myColorAnimatedButton.Width = 200;
                //myColorAnimatedButton.HorizontalAlignment = HorizontalAlignment.Left;
                //myColorAnimatedButton.Content = "Another Button";

                //// Create a SolidColorBrush to paint the button's background.
                //SolidColorBrush myBackgroundBrush = new SolidColorBrush();
                //myBackgroundBrush.Color = Colors.Blue;

                //// Because a Brush isn't a FrameworkElement, it doesn't
                //// have a Name property to set. Instead, you just
                //// register a name for the SolidColorBrush with
                //// the page where it's used.
                //this.RegisterName("myAnimatedBrush", myBackgroundBrush);

                //// Use the brush to paint the background of the button.
                //myColorAnimatedButton.Background = myBackgroundBrush;

                //// Create a ColorAnimation to animate the button's background.
                //ColorAnimation myColorAnimation = new ColorAnimation();
                //myColorAnimation.From = Colors.Red;
                //myColorAnimation.To = Colors.Blue;
                //myColorAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(7000));

                //// Configure the animation to target the brush's Color property.
                //Storyboard.SetTargetName(myColorAnimation, "myAnimatedBrush");
                //Storyboard.SetTargetProperty(myColorAnimation, new PropertyPath(SolidColorBrush.ColorProperty));

                //// Create a storyboard to contain the animation.
                //Storyboard myColorAnimatedButtonStoryboard = new Storyboard();
                //myColorAnimatedButtonStoryboard.Children.Add(myColorAnimation);

                //// Animate the button background color when it's clicked.
                //myColorAnimatedButton.Click += delegate (object sender, RoutedEventArgs args)
                //{
                //    myColorAnimatedButtonStoryboard.Begin(myColorAnimatedButton);
                //};

                //stack1.Children.Add(image2);
                //this.Content = stack1;

            }


             void Image2_MouseEnter(object sender, MouseEventArgs e)
            {
                //if(this._mystoryboard != null)
                //{
                //    this._mystoryboard.Begin(sender as Image);
                //}
                scaleTransform.ScaleX = 2;
                scaleTransform.ScaleY = 2;
            }

            //private void buildAnimatedImagesExample()
            //{
            //    NameScope.SetNameScope(this, new NameScope());

            //    //this.WindowTitle = "Animate Properties using Storyboards";
            //    StackPanel myStackPanel = new StackPanel();
            //    myStackPanel.MinWidth = 500;
            //    myStackPanel.Margin = new Thickness(30);
            //    myStackPanel.HorizontalAlignment = HorizontalAlignment.Left;
            //    TextBlock myTextBlock = new TextBlock();
            //    myTextBlock.Text = "Storyboard Animation Example";
            //    myStackPanel.Children.Add(myTextBlock);

            //    //
            //    // Create and animate the first button.
            //    //

            //    // Create a button.
            //    Button myWidthAnimatedButton = new Button();
            //    myWidthAnimatedButton.Height = 30;
            //    myWidthAnimatedButton.Width = 200;
            //    myWidthAnimatedButton.HorizontalAlignment = HorizontalAlignment.Left;
            //    myWidthAnimatedButton.Content = "A Button";

            //    // Set the Name of the button so that it can be referred
            //    // to in the storyboard that's created later.
            //    // The ID doesn't have to match the variable name;
            //    // it can be any unique identifier.
            //    myWidthAnimatedButton.Name = "myWidthAnimatedButton";

            //    // Register the name with the page to which the button belongs.
            //    this.RegisterName(myWidthAnimatedButton.Name, myWidthAnimatedButton);

            //    // Create a DoubleAnimation to animate the width of the button.
            //    DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            //    myDoubleAnimation.From = 200;
            //    myDoubleAnimation.To = 300;
            //    myDoubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(3000));

            //    // Configure the animation to target the button's Width property.
            //    Storyboard.SetTargetName(myDoubleAnimation, myWidthAnimatedButton.Name);
            //    Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Button.WidthProperty));

            //    // Create a storyboard to contain the animation.
            //    Storyboard myWidthAnimatedButtonStoryboard = new Storyboard();
            //    myWidthAnimatedButtonStoryboard.Children.Add(myDoubleAnimation);

            //    // Animate the button width when it's clicked.
            //    myWidthAnimatedButton.Click += delegate (object sender, RoutedEventArgs args)
            //    {
            //        myWidthAnimatedButtonStoryboard.Begin(myWidthAnimatedButton);
            //    };

            //    myStackPanel.Children.Add(myWidthAnimatedButton);

            //    //
            //    // Create and animate the second button.
            //    //

            //    // Create a second button.
            //    Button myColorAnimatedButton = new Button();
            //    myColorAnimatedButton.Height = 30;
            //    myColorAnimatedButton.Width = 200;
            //    myColorAnimatedButton.HorizontalAlignment = HorizontalAlignment.Left;
            //    myColorAnimatedButton.Content = "Another Button";

            //    // Create a SolidColorBrush to paint the button's background.
            //    SolidColorBrush myBackgroundBrush = new SolidColorBrush();
            //    myBackgroundBrush.Color = Colors.Blue;

            //    // Because a Brush isn't a FrameworkElement, it doesn't
            //    // have a Name property to set. Instead, you just
            //    // register a name for the SolidColorBrush with
            //    // the page where it's used.
            //    this.RegisterName("myAnimatedBrush", myBackgroundBrush);

            //    // Use the brush to paint the background of the button.
            //    myColorAnimatedButton.Background = myBackgroundBrush;

            //    // Create a ColorAnimation to animate the button's background.
            //    ColorAnimation myColorAnimation = new ColorAnimation();
            //    myColorAnimation.From = Colors.Red;
            //    myColorAnimation.To = Colors.Blue;
            //    myColorAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(7000));

            //    // Configure the animation to target the brush's Color property.
            //    Storyboard.SetTargetName(myColorAnimation, "myAnimatedBrush");
            //    Storyboard.SetTargetProperty(myColorAnimation, new PropertyPath(SolidColorBrush.ColorProperty));

            //    // Create a storyboard to contain the animation.
            //    Storyboard myColorAnimatedButtonStoryboard = new Storyboard();
            //    myColorAnimatedButtonStoryboard.Children.Add(myColorAnimation);

            //    // Animate the button background color when it's clicked.
            //    myColorAnimatedButton.Click += delegate (object sender, RoutedEventArgs args)
            //    {
            //        myColorAnimatedButtonStoryboard.Begin(myColorAnimatedButton);
            //    };

            //    myStackPanel.Children.Add(myColorAnimatedButton);
            //    this.Content = myStackPanel;





            //}
        }

        private Image transpileIcon(int i, ref int width, IFileSystemObjectBase? fileSystemObject)
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


    } }
