using Microsoft.VisualStudio.TestTools.UnitTesting;
using Iskola;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iskola.Tests
{
    [TestClass()]
    public class TanulokTests
    {
        [TestMethod()]
        public void EgyedikulcsTest()
        {
            Tanulok t = new Tanulok("2007;a;Ruff Noemi");
            Assert.AreEqual("7arufnoe", t.Egyedikulcs());
        }
    }
}