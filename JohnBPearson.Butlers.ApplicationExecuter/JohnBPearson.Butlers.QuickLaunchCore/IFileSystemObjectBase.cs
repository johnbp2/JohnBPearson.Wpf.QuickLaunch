using System.Drawing;
using JohnBPearson.Wpf.QuickLaunchCore.FileMetaDataModel;

namespace JohnBPearson.Wpf.QuickLaunchCore.FileMetaDataModel
{
    public interface IFileSystemObjectBase
    {
        string Extension
        {
            get;
        }
        string FullPath
        {
            get;
        }
        Icon Icon
        {
            get;
        }
        string Name
        {
            get;
        }
        Extension Type
        {
            get;
        }

        void Run();
    }
}