using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JohnBPearson.FileObjects.FileMetaDataModel;

namespace JohnBPearson.FileObjects
{
    internal interface IBinaryLinkFormat:IFileSystemObjectBase
    {
        void run();
    }
}
