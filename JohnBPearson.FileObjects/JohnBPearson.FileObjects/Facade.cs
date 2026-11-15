using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CustomExtensions;
using JohnBPearson.FileObjects.Model;
//using Securify.ShellLink;

namespace JohnBPearson.FileObjects
{
    public class Facade
    {


        private static IDirectory _directory;
        public static IDirectory Directory
        {
            get
            {

                return _directory;
            }
        }

        public Facade()//string dirPath)
        {

            //if(isStringValidDir(dirPath))
            //{

            //    _directoryPath = dirPath;
            //}
        }

        public static IEnumerable<IFileSystemObjectBase> GetFileSystemObjects(string directoryPath)
        {
            var dir = new System.IO.DirectoryInfo(directoryPath);
            if(dir.Exists)
            {
                 _directory = new Directory(directoryPath, dir);

                return _directory.Contents;




            }
            else
            {
                throw new Exception($"Directory path {directoryPath} is not valid. Please set the directory path before accessing FileSystemObjects.");
            }


        }




    }


}

namespace CustomExtensions
{

    //FileExtensionEnum methods must be defined in a static class
    public static class StringExtension
    {
        // This is the extension method.
        // The first parameter takes the "this" modifier
        // and specifies the type for which the method is defined.
        public static string SanitizeFileExtension(this string str)
        {
            if(str.Contains('.') && str.Length == 4 && str.StartsWith("."))
            {
                return str.Substring(1, 3);
            }
            return str;
        }

        public static string ConvertWhitespacesToSingleSpaces(this string value)
        {
            return Regex.Replace(value, @"\s+", " ");
        }
    }
}
