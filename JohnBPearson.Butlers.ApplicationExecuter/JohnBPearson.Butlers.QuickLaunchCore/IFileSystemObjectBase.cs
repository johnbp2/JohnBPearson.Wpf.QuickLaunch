using System.Drawing;
using JohnBPearson.Butlers.QuickLaunchCore.FileMetaDataModel;

namespace JohnBPearson.Butlers.QuickLaunchCore.FileMetaDataModel
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