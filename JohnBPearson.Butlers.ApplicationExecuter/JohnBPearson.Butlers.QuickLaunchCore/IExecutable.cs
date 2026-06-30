using JohnBPearson.Wpf.QuickLaunchCore.FileMetaDataModel;

namespace JohnBPearson.Wpf.QuickLaunchCore
{
    public interface IExecutable: IFileSystemObjectBase 
    {
        void Run();
    }
}