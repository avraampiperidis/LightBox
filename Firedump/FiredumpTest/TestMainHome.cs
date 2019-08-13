using System;
using Firedump;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FiredumpTest
{
    [TestClass]
    public class TestMainHome
    {
        [TestMethod]
        public void Init()
        {
            MainHome mainHome = new MainHome();
            Assert.AreEqual(4, mainHome.ChildControls.Count);
            mainHome.Dispose();
        }
    }
}
