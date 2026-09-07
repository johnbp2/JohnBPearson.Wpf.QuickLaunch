using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection.Metadata;

namespace JohnBPearson.FileObjects.Model
{

public enum FileExtensionEnum
{
    dir = 0,bat =1, exe = 2, lnk = 3, url = 4
}
    public static class Constants
    {

        public  const string lnk = ".lnk";
        public  const string exe = ".exe";
        public  const string dir = "";
        public  const string bat = ".bat";
        public const string url = ".url";

  
       public static IEnumerable<string> getEnumerator()
        {
            yield return dir;
            yield return bat;
            
            yield return exe;
            yield return lnk;

            yield return url;
        } 
    }

    

}