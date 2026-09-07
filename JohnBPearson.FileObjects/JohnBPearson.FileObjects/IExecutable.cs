using JohnBPearson.FileObjects.Model;

namespace JohnBPearson.FileObjects
{
    public interface IExecutable: IFileSystemObjectBase 
    {
        void Run();
    }
}