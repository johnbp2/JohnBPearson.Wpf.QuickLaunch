using System.Drawing;
using JohnBPearson.FileObjects.FileMetaDataModel;

namespace JohnBPearson.FileObjects.FileMetaDataModel
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
        FileExtensionEnum Type
        {
            get;
        }

        void Run();
    }
}