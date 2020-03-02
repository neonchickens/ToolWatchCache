using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToolWatchCache;

namespace ToolWatchCacheTest
{
    [TestClass]
    public class TWCacheTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            MyTWCache twc = new MyTWCache();
            twc.Set("NewEmpName", "Weston");
            twc.Set("NewEmpAge", 21);

            Assert.AreEqual("Weston", (string)twc.Get("NewEmpName"));
            Assert.AreEqual(21, (int)twc.Get("NewEmpAge"));
        }

        [TestMethod]
        public void ContainsTest()
        {
            MyTWCache twc = new MyTWCache();
            twc.Set("NewEmpName", "Weston");
            twc.Set("NewEmpAge", 21);

            Assert.AreEqual(true, twc.Contains("NewEmpName"));
            Assert.AreEqual(false, twc.Contains("Location"));
        }

        [TestMethod]
        public void DeleteTest()
        {
            MyTWCache twc = new MyTWCache();
            twc.Set("NewEmpName", "Weston");
            twc.Set("NewEmpAge", 21);

            object obj = twc.Delete("NewEmpAge");

            Assert.AreEqual(21, (int)obj);
            Assert.AreEqual(false, twc.Contains("NewEmpAge"));
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void DeleteExceptionTest()
        {
            MyTWCache twc = new MyTWCache();
            twc.Set("NewEmpName", "Weston");
            twc.Set("NewEmpAge", 21);

            twc.Delete("Location");
        }

        [TestMethod]
        public void MGetTest()
        {
            MyTWCache twc = new MyTWCache();
            twc.Set("NewEmpName", "Weston");
            twc.Set("NewEmpAge", 21);

            object[] obj = twc.MGet("NewEmpAge", "NewEmpName");

            Assert.AreEqual(21, (int)obj[0]);
            Assert.AreEqual("Weston", (string)obj[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void MGetExceptionTest()
        {
            MyTWCache twc = new MyTWCache();
            twc.Set("NewEmpName", "Weston");
            twc.Set("NewEmpAge", 21);

            object[] obj = twc.MGet("NewEmpAge", "NewEmpName", "Location");
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void GetExceptionTest()
        {
            MyTWCache twc = new MyTWCache();
            twc.Set("NewEmpName", "Weston");
            twc.Set("NewEmpAge", 21);

            object[] obj = twc.MGet("Location");
        }

        [TestMethod]
        public void SetNTTest()
        {
            MyTWCache twc = new MyTWCache();
            twc.Set("NewEmpName", "Weston");
            twc.Set("NewEmpAge", 21);
            twc.SetNX("NewEmpName", "Other Guy");

            Assert.AreEqual("Weston", (string)twc.Get("NewEmpName"));
        }

        [TestMethod]
        public void ListKeysTest()
        {
            MyTWCache twc = new MyTWCache();
            twc.Set("NewEmpName", "Weston");
            twc.Set("NewEmpAge", 21);

            List<string> keys = new List<string>(twc.ListKeys());

            Assert.AreEqual(true, keys.Contains("NewEmpName"));
            Assert.AreEqual(true, keys.Contains("NewEmpAge"));
            Assert.AreEqual(false, keys.Contains("Location"));
        }
    }
}
