using System;

using JohnBPearson.Butlers.QuickLaunch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        const string testDir = "c:\\temp";
        [TestMethod]
        public void TestMethod1()
        {

            var exec = new JohnBPearson.Butlers.QuickLaunch.Executable(testDir);
            Assert.IsNotNull(exec);
            Assert.IsTrue(exec.Name.Length > 0);
            Assert.IsTrue(exec.Type == FileSystemObjectType.Directory);
         //   Assert.IsTrue(exec.Extension.Length > 0);
         //   Assert.IsTrue(exec.Icon != null);
        }

        [TestMethod]
        public void testFacade()
        {
            var fac = new Facade(testDir);
            Assert.IsTrue(fac.Executables.Count > 0);
            foreach(var exec in fac.Executables)
            {
                Assert.IsTrue(exec.Icon != null);

            }

        }
    }
}
