using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection.Metadata;

<<<<<<<< HEAD:JohnBPearson.FileObjects/JohnBPearson.FileObjects/Model/Constants.cs
namespace JohnBPearson.FileObjects.Model
========
namespace JohnBPearson.FileObjects.FileModel
>>>>>>>> f7d82559a00f21c7dc12d9aeb98277b27b5e9ddd:JohnBPearson.FileObjects/JohnBPearson.FileObjects/FileModel/Constants.cs
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