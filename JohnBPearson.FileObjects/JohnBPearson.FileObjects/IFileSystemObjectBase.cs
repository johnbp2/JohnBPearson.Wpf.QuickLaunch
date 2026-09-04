using System.Drawing;
using JohnBPearson.FileObjects.FileModel;

namespace JohnBPearson.FileObjects.FileModel
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