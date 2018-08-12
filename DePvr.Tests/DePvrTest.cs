using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DePvr.Tests
{
    [TestClass]
    public class DePvrTest
    {
        private const string TestPvrPath = "Test.pvr";
        private const string TestExportPath = "Test.png";
        private const string TestFlipExportPath = "Test.Flipped.png";

        private Pvr _pvr;

        [TestInitialize]
        public void LoadPvrFromFileTest()
        {
            _pvr = Pvr.LoadFromFile(TestPvrPath);
        }

        [TestMethod]
        public void LoadPvrFromMemoryTest()
        {
            _pvr = Pvr.LoadFromBytes(
                File.ReadAllBytes(TestPvrPath)
            );
        }

        [TestMethod]
        public void FlipTest()
        {
            var vertical = _pvr.FlipVertical();
            var horizontal = _pvr.FlipHorizontal();

            Assert.IsTrue(vertical && horizontal);
        }

        [TestMethod]
        public void GetHeaderTest()
        {
            Console.WriteLine($"Width: {_pvr.Width}");
            Console.WriteLine($"Height: {_pvr.Height}");
            Console.WriteLine($"Size: {_pvr.DataSize}");
        }

        [TestMethod]
        public void GetDataTest()
        {
            var bytes = _pvr.Data;
            foreach (var b in bytes)
            {
                Console.Write("{0:X}", b);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            _pvr.Export(TestExportPath);
        }

        [TestMethod]
        public void FlipExportTest()
        {
            _pvr.FlipVertical();
            _pvr.Export(TestFlipExportPath);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _pvr.Dispose();
        }
    }
}
