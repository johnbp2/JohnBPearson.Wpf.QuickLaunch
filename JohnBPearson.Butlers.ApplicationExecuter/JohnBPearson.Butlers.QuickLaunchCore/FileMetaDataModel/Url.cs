
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using global::JohnBPearson.Butlers.QuickLaunchCore.FileMetaDataModel;

    namespace JohnBPearson.Butlers.QuickLaunchCore.FileMetaDataModel
    {

        public class Url : FileSystemObjectBase, IFileSystemObjectBase
        {



            public Uri Target
            {
                get; private set;
            }

            public Url(string fullPath, FileInfo info) : base(fullPath, info)
            {
                var lines = File.ReadAllLines(fullPath);

                foreach(var line in lines)
                {
                    // line in file looks like this "URL=http://google.com/"
                    if(line.Contains("URL") || line.Contains("url"))
                    {

                        var target = line.Remove(0, 4);
                        Target = new Uri(target);
                        //var linkIndex = line.IndexOf("h");
                        //if (linkIndex != -1)
                        //{
                        //    line.
                        //}
                    }


                }
            }

            public override void Run()
            {
                System.Diagnostics.Process.Start(Target.OriginalString);
            }
        }
    }

