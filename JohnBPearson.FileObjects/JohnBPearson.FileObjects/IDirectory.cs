using System.Collections.Generic;

namespace JohnBPearson.FileObjects
{
    public interface IDirectory : IFileSystemObjectBase
    {
        IEnumerable<IFileSystemObjectBase> Contents
        {
            get;
        }

      
    }
}
