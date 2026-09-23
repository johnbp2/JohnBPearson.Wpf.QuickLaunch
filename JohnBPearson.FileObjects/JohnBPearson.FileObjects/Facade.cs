using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CustomExtensions;
using JohnBPearson.FileObjects.Model;
using Securify.ShellLink;

namespace JohnBPearson.FileObjects
{
    public class Facade
    {


        private static List<IFileSystemObjectBase> _executables;
        private static bool _pathChanged = false;

        public static  List<IFileSystemObjectBase> FileSystemObjects
        {
            get
            {
                if(_executables == null || _pathChanged)
                {
                 
                    if(isStringValidDir(_directoryPath))
                    {
                        _executables = new List<IFileSystemObjectBase>();
                        InstantiateFileSystemObjects(_directoryPath);
                        _pathChanged = false;
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
            set {
                if(value != _directoryPath)
                {
                    _pathChanged = true;
                }
                _directoryPath = value; 
            }
        }

        private static string _directoryPath;
        public  Facade(string dirPath)
        {

            if(isStringValidDir(dirPath))
            {

                _directoryPath = dirPath;
            }
        }
        public static void RefreshFileSystemObjects()
        {
            _executables.Clear();
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
                    if(file.Extension == Constants.lnk)
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
                    else if(FileExtension.ExtensionStrings.Contains(file.Extension.SanitizeFileExtension()))


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
                _executables.Add(fileObject);
            }
        }

        private static bool isStringValidDir(string dirPath)
        {
            if(string.IsNullOrWhiteSpace(dirPath))
            {

                return false;
            }
            var exists =  System.IO.Directory.Exists(dirPath);
            if(exists)
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
