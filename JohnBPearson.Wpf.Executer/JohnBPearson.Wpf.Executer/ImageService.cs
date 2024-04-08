using System;
using System.Collections.Generic;
using System.Configuration.Internal;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace JohnBPearson.Wpf.Executer
{
    internal class ImageService
    {


        internal System.Windows.Media.Imaging.BitmapSource ImageSourceFromIcon(System.Drawing.Icon icon)
        {
            
              return Imaging.CreateBitmapSourceFromHIcon(icon.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
       

        internal BitmapImage IconToBitmapImage(System.Drawing.Icon icon)
        {




             MemoryStream ms = new MemoryStream();
           // using(MemoryStream ms = new MemoryStream())
              //   {
                System.Drawing.Bitmap dImg = icon.ToBitmap();
                    dImg.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    ms.Position = 0;
                    var bImg = new System.Windows.Media.Imaging.BitmapImage();
                    bImg.BeginInit();
                    bImg.StreamSource = ms;
                    bImg.EndInit();
                    return bImg;
            //    }
            }

    }
}


  


