using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.Butlers.QuickLaunchCore.FileMetaDataModel
{

  
    internal static class FileExtension
    {

        private static List<Tuple<string, int>> _extensions;
        public static IEnumerable<Tuple<string, int>> Extensions
        {
            get
            {
                return _extensions as IEnumerable<Tuple<string, int>>;
            }


        }
        static FileExtension()
        {
            _extensions = new List<Tuple<string, int>>();
            int i = 0;
            foreach (var item in Enum.GetValues(typeof(Extention)))
            {

                _extensions.Add(new Tuple<string, int>($".{item.ToString()}",i));
                i++;
            }
        
            //foreach (var item in Enum.GetNames(typeof(Extention)))
            //{
            //    _extensions.Add(string.Concat(".",item.ToString()));
            //}
        }
    }
}
