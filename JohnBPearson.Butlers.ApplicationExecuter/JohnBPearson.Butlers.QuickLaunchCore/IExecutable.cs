using JohnBPearson.Butlers.QuickLaunchCore.FileMetaDataModel;

namespace JohnBPearson.Butlers.QuickLaunchCore
{
    public interface IExecutable: IFileSystemObjectBase 
    {
        void Run();
    }
}