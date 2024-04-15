using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JohnBPearson.Butlers.QuickLaunchCore.FileMetaDataModel;

namespace JohnBPearson.Butlers.QuickLaunchCore
{
    internal interface IBinaryLinkFormat:IFileSystemObjectBase
    {
        void run();
    }
}
