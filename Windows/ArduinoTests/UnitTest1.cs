using System;
using Arduino;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArduinoTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ControllerTemplate page = new ControllerTemplate(ArduinoData.Default);

            Assert.IsTrue(page.TransformText() != null);
        }
    }
}
