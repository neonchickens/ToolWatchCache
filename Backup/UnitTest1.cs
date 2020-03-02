using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToolWatchCacheTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetTest()
        {
            MyTWCache twc = new MyTWCache();
            tws.Set("NewEmpName", "Weston");
            tws.Set("NewEmpAge", 21);

            Assert.Equals("Weston", (string)TWCache.Get("NewEmpName"));
            Assert.Equals(21, (int)TWCache.Get("NewEmpAge"));
        }
    }
}
