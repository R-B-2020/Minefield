using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minefield.Business.Interface;
using Minefield.Business.Manager;
using System;

namespace Minefield.Tests
{
    [TestClass]
    public class PrintManagerUnitTests
    {
        private readonly IPrintManager printManager = PrintManager.GetInstance();

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PrintField_throw_exception_if_matirx_input_is_null()
        {
            printManager.PrintField(null, true);
        }

    }
}
