using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using JohnBPearson.Wpf.Executer.ViewModels;
using JohnBPearson.Wpf.QuickLaunchCore.FileMetaDataModel;

namespace JohnBPearson.Wpf.Executer.Controls
{
    public class Image : System.Windows.Controls.Image
    {


        public IFileSystemObjectBase FileSystemObjectBase
        {
            get; set;
        }

        public ScaleTransform scaleTransform
        {
            get; set;
        }

       
        public Image(ScaleTransform scaleTransform, IFileSystemObjectBase fileSystemObjectBase): base()
        {
            this.FileSystemObjectBase = fileSystemObjectBase;
        this.scaleTransform = scaleTransform;
        }
    }
}
