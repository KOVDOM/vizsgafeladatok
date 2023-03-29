using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelsinkiCLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelsinkiCLI.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void Feladat4Test()
        {
            Assert.AreEqual(2, Program.Feladat4(5));
            Assert.AreEqual(3, Program.Feladat4(4));
            Assert.AreEqual(4, Program.Feladat4(3));
        }
    }
}