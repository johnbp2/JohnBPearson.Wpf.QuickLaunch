using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection.Metadata;

namespace JohnBPearson.Butlers.QuickLaunchCore.FileMetaDataModel
{

public enum Extension
{
    dir = 0, ini = 1, exe = 2, lnk = 3, url = 4
}
    public static class Constants
    {

        public  const string lnk = ".lnk";
        public  const string exe = ".exe";
        public  const string dir = "";
        public  const string ini = ".ini";
        public const string url = ".url";

  
       public static IEnumerable<string> getEnumerator()
        {
            yield return dir;
            yield return ini;
            
            yield return exe;
            yield return lnk;

            yield return url;
        } 
    }

    

}