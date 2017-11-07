using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApp.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void IfArgumentsNotPassedIn_ShouldReturnNonZero()
        {
            // Arrange

            // Act
            var actual = Program.Main(new string[] { });

            // Assert
            Assert.AreNotEqual(0, actual);
        }
    }
}
