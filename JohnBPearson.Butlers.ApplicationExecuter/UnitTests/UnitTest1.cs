using System;
using JohnBPearson.Butlers.QuickLaunchCore.FileMetaData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        const string testDir = "c:\\Users\\johnj\\AppData\\Roaming\\Microsoft\\Internet Explorer\\Quick Launch\\";
        public void TestMethod1()
        {

            var exec = new JohnBPearson.Butlers.QuickLaunchCore.Executable(testDir);
            var link = new JohnBPearson.Butlers.QuickLaunchCore.BinaryLinkFormat(exec )
            Assert.IsNotNull(exec);
            Assert.IsTrue(exec.Name.Length > 0);
            Assert.IsTrue(exec.Type == Extention.Directory);
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
                if(fso.Type == Extention.BinaryLinkFormat)
                {

                    Assert.IsTrue(((BinaryLinkFormat)fso).TargetPath != "");
                        

                  } 
            
            }

        }
    }
}
