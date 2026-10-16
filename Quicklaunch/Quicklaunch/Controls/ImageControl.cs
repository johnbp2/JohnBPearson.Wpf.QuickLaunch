using JohnBPearson.FileObjects;
using JohnBPearson.FileObjects.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ToolTip = System.Windows.Controls.ToolTip;

namespace Quicklaunch.Controls
{
    public class ImageControl : System.Windows.Controls.Image
    {


        public IFileSystemObjectBase FileSystemObjectBase
        {
            get; set;
        }

        public ScaleTransform scaleTransform
        {
            get; set;
        }


        public ImageControl(ScaleTransform scaleTransform, IFileSystemObjectBase fileSystemObjectBase) : base()
        {
            this.FileSystemObjectBase = fileSystemObjectBase;
            this.scaleTransform = scaleTransform;

        }

        public ImageControl(ScaleTransform scaleTransform, IFileSystemObjectBase fileSystemObjectBase, string tooltipConents) : base()
        {
            this.FileSystemObjectBase = fileSystemObjectBase;
            this.scaleTransform = scaleTransform;
            this.setTooltip(tooltipConents);
        }

        private void setTooltip(string content) 
        {


            // Source - https://stackoverflow.com/a/49650044
            // Posted by Anthony
            // Retrieved 2026-10-13, License - CC BY-SA 3.0

            var tooltip = new ToolTip { Content = content };
            this.ToolTip = tooltip;
            //tooltip.Opened += async delegate (object o, RoutedEventArgs args)
            //{
            //    var s = o as ToolTip;
            //    // let the tooltip display for 1 second
            //    await Task.Delay(1000);
            //    s.IsOpen = false;
            //    // wait till the close tooltip animation finishes before changing to old tooltip text
            //    await Task.Delay(1000);
            //    s.Content = "Old tooltip text";
            //};
            //tooltip.IsOpen = true;

        }
    }
}
