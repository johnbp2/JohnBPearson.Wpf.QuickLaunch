using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.FileObjects
{
    public interface IUrl: IFileSystemObjectBase
    {
        Uri Target { get; }
    }
}
