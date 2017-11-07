using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApp.Tests
{
    [TestClass]
    public class ParseMenuXmlServiceTests
    {
        [TestMethod]
        public void ReadMenu_ShouldReturnSuccessfully()
        {
            // Arrange
            var target = new ParseMenuXmlService();
                        
            // Act
            var actual = target.ReadMenu("SchedAero Menu.txt");

            // Assert
            Assert.IsNotNull(actual);
            // ... TODO: More checks here, this just gives us a test to drive the implementation
        }
    }
}
