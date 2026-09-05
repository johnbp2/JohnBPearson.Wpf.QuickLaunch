using JohnBPearson.FileObjects.FileModel;

namespace JohnBPearson.FileObjects
{
    public interface IExecutable: IFileSystemObjectBase 
    {
        void Run();
    }
}