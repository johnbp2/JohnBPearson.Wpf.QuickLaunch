using System.Drawing;
using JohnBPearson.FileObjects.Model;

namespace JohnBPearson.FileObjects.Model
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
        string ParentPath
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