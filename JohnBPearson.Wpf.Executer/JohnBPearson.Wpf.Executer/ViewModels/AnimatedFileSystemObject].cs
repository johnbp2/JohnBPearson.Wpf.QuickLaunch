using JohnBPearson.Butlers.QuickLaunchCore.FileMetaDataModel;
using System.Windows.Controls;
using System.Windows.Media;

namespace JohnBPearson.Wpf.Executer.ViewModels
{
    internal class AnimatedFileSystemObject
    {
        public IFileSystemObjectBase FileSystemObjectBase { get; set; }

        public ScaleTransform scaleTransform { get; set; }

        public Image Image { get; set; }

        internal AnimatedFileSystemObject(IFileSystemObjectBase filesystemObject, ScaleTransform scaleTransform, Image image)
        {
            this.FileSystemObjectBase = filesystemObject;
            this.scaleTransform = scaleTransform;
            this.Image = image;
        }
    }
}
