using Microsoft.VisualStudio.TestTools.UnitTesting;
using vizsgateszt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vizsgateszt.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void DerekszogTest()
        {
            haromszog h = new haromszog("3 4 5");
            Assert.AreEqual(true, Program.Derekszog(h));
        }
    }
}