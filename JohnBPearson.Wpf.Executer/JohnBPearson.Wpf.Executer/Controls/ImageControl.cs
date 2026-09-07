using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using JohnBPearson.FileObjects.Model;

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

       
        public ImageControl(ScaleTransform scaleTransform, IFileSystemObjectBase fileSystemObjectBase): base()
        {
            this.FileSystemObjectBase = fileSystemObjectBase;
        this.scaleTransform = scaleTransform;
        }
    }
}
