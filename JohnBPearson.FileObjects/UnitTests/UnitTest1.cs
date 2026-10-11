using System;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using JohnBPearson.FileObjects;
using JohnBPearson.FileObjects.Model;
using Quicklaunch.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        const string testDir = "c:\\Users\\johnj\\AppData\\Roaming\\Microsoft\\Internet Explorer\\Quick Launch\\";


        [TestMethod]
        public void testFacade()
        {

            this.buildTestDirectory();
           // var fac = new Facade(testDir);
           Facade.DirectoryPath = testDir;
            Assert.IsTrue(Facade.FileSystemObjects.ToList().Count > 0);
            foreach(var fso in Facade.FileSystemObjects)
            {
                Assert.IsTrue(fso.Icon != null);
                if(fso.Type == FileExtensionEnum.lnk)
                {

                    Assert.IsTrue(((IBinaryLinkFormat)fso).TargetPath != "");
                        

                  } 
            
            }

        }


        private void buildTestDirectory()
        {
            if (!Directory.Exists(testDir))
            {
                Directory.CreateDirectory(testDir);
                FileHelperService.CreateShortcut(@"c:\windows\system32\notepad.exe","",Path.Combine(testDir,"notepad.lnk"));
            }

           
          
        }
    }
}
