using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JohnBPearson.Wpf.QuickLaunchCore.FileMetaDataModel;

namespace JohnBPearson.Wpf.QuickLaunchCore
{
    internal interface IBinaryLinkFormat:IFileSystemObjectBase
    {
        void run();
    }
}
