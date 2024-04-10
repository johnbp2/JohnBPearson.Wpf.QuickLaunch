using System.Drawing;

namespace JohnBPearson.Butlers.QuickLaunchCore
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
        FileSystemObjectType Type
        {
            get;
        }

        void Run();
    }
}