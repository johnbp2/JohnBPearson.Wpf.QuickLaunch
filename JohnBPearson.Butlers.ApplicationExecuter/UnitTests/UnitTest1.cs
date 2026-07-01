using System;
using System.IO;
using JohnBPearson.Wpf.QuickLaunchCore;
using JohnBPearson.Wpf.QuickLaunchCore.FileMetaDataModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        const string testDir = "c:\\Users\\johnj\\AppData\\Roaming\\Microsoft\\Internet Explorer\\Quick Launch\\";
        public void TestMethod1()
        {
           // var info = new FileInfo(testDir);
            var exec = new MockExecutable();
            // var link = new JohnBPearson.Wpf.QuickLaunchCore.BinaryLinkFormat(exec);
            Assert.IsNotNull(exec);
            Assert.IsTrue(exec.Name.Length > 0);
            Assert.IsTrue(exec.Type == JohnBPearson.Wpf.QuickLaunchCore.FileMetaDataModel.FileExtensionEnum.dir);
         //   Assert.IsTrue(fso.Extension.Length > 0);
         //   Assert.IsTrue(fso.Icon != null);
        }

        [TestMethod]
        public void testFacade()
        {
            var fac = new Facade(testDir);
            Assert.IsTrue(fac.FileSystemObjects.Count > 0);
            foreach(var fso in fac.FileSystemObjects)
            {
                Assert.IsTrue(fso.Icon != null);
                if(fso.Type == FileExtensionEnum.lnk)
                {

                    Assert.IsTrue(((BinaryLinkFormat)fso).TargetPath != "");
                        

                  } 
            
            }

        }
    }
}
