using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JohnBPearson.FileObjects.Model;

namespace JohnBPearson.FileObjects
{

    public interface IDirectory : IFileSystemObjectBase
    {
        IEnumerable<IFileSystemObjectBase> Contents
        {
            get;
        }

        void Run();
    }
    public interface IBinaryLinkFormat:IFileSystemObjectBase
    {
        void run();
        string TargetPath
        {
            get;
        }
    }
}
