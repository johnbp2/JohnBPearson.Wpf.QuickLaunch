using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CustomExtensions;
using JohnBPearson.FileObjects.FileMetaDataModel;
using Securify.ShellLink;

namespace JohnBPearson.FileObjects
{
    public class Facade
    {


        private static List<IFileSystemObjectBase> _executables;


        public static  List<IFileSystemObjectBase> FileSystemObjects
        {
            get
            {
                if(_executables == null)
                {
                    _executables = new List<IFileSystemObjectBase>();
                    if(!string.IsNullOrWhiteSpace(_directoryPath))
                    {
                        InstantiateFileSystemObjects(_directoryPath);
                    }
                    else
                    {
                        throw new Exception("Directory path is not set. Please set the directory path before accessing FileSystemObjects.");
                    }


                }
                return _executables;
            }
        }

        public static string DirectoryPath
        {
            get => _directoryPath;
            set => _directoryPath = value;
        }

        private static string _directoryPath;
        public  Facade(string dirPath)
        {

            if(isStringValidDir(dirPath))
            {

                _directoryPath = dirPath;
            }
        }
        public void RefreshFileSystemObjects()
        {
         InstantiateFileSystemObjects(_directoryPath);
        }
        private static void InstantiateFileSystemObjects(string directoryPath)
        {
            var dir = new System.IO.DirectoryInfo(directoryPath);
            if(dir.Exists)
            {
                var fact = new FileSystemObjectFactory();
                var files = dir.EnumerateFiles();
                foreach(var file in files)
                {
                    if(FileExtension.ExtensionStrings.Contains(file.Extension.SanitizeFileExtension()))
                    {
                
                        try
                        {

                            var sc = Shortcut.ReadFromFile(file.FullName);
                            if(sc.LinkFlags.HasFlag(Securify.ShellLink.Flags.LinkFlags.HasLinkInfo))
                            {
                                AddFileToObjects(file);
                            }

                        }
                        catch(ArgumentException ex)
                        {

                            // swallow it for now
                        }

                    }
                    else
                    {

                        AddFileToObjects(file);
                    }
                }

                // dir.GetFiles()
            }


        }

        private static void AddFileToObjects(System.IO.FileInfo file)
        {
            var fileObject = FileSystemObjectFactory.Build(file.FullName, file);
            if(fileObject != null)
            {
                FileSystemObjects.Add(fileObject);
            }
        }

        private static bool isStringValidDir(string dirPath)
        {
            if(string.IsNullOrWhiteSpace(dirPath))
            {

                return false;
            }
            var test = new System.IO.DirectoryInfo(dirPath);
            if(test.Exists)
            {

                return true;
            }
            else
            {
                return false;
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
