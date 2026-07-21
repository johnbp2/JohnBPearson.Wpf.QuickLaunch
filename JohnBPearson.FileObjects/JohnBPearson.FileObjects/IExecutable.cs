using JohnBPearson.FileObjects.FileMetaDataModel;

namespace JohnBPearson.FileObjects
{
    public interface IExecutable: IFileSystemObjectBase 
    {
        void Run();
    }
}