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
        Extention Type
        {
            get;
        }

        void Run();
    }
}