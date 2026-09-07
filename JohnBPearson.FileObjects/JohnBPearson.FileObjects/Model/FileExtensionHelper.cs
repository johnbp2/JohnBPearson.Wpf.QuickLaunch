using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

<<<<<<<< HEAD:JohnBPearson.FileObjects/JohnBPearson.FileObjects/Model/FileExtensionHelper.cs
namespace JohnBPearson.FileObjects.Model
========
namespace JohnBPearson.FileObjects.FileModel
>>>>>>>> f7d82559a00f21c7dc12d9aeb98277b27b5e9ddd:JohnBPearson.FileObjects/JohnBPearson.FileObjects/FileModel/FileExtensionHelper.cs
{

  
    internal static class FileExtensionHelper
    {

        private static List<Tuple<string, int>> _extensions;
        public static IEnumerable<Tuple<string, int>> Extensions
        {
            get
            {
                return _extensions as IEnumerable<Tuple<string, int>>;
            }


        }
        static FileExtensionHelper()
        {
            _extensions = new List<Tuple<string, int>>();
            int i = 0;
            foreach (var item in Enum.GetValues(typeof(FileExtensionEnum)))
            {

                _extensions.Add(new Tuple<string, int>($".{item.ToString()}",i));
                i++;
            }
        
            //foreach (var item in Enum.GetNames(typeof(FileExtensionEnum)))
            //{
            //    _extensions.Add(string.Concat(".",item.ToString()));
            //}
        }
    }
}
