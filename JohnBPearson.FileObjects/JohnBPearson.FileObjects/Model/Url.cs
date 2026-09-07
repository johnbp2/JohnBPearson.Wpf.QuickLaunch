
    using System;
    using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
<<<<<<<< HEAD:JohnBPearson.FileObjects/JohnBPearson.FileObjects/Model/Url.cs
    using global::JohnBPearson.FileObjects.Model;

    namespace JohnBPearson.FileObjects.Model
========
    using global::JohnBPearson.FileObjects.FileModel;

    namespace JohnBPearson.FileObjects.FileModel
>>>>>>>> f7d82559a00f21c7dc12d9aeb98277b27b5e9ddd:JohnBPearson.FileObjects/JohnBPearson.FileObjects/FileModel/Url.cs
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
            // System.Diagnostics.Process.Start(Target.OriginalString);

           var url = Target.OriginalString.Replace("&", "^&");
            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
        }
        }
    }

