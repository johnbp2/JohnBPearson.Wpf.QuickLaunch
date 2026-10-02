using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JohnBPearson.FileObjects.Model;

namespace JohnBPearson.FileObjects
{
    public interface IBinaryLinkFormat:IFileSystemObjectBase
    {
        
        string TargetPath
        {
            get;
        }
    }
}
