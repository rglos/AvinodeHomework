using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ConsoleApp.Tests
{
    [TestClass]
    public class IdentifyActiveItemsServiceTests
    {
        [TestMethod]
        public void IdentifyActiveItems_ShouldBeActiveForChildAndParents()
        {
            // Arrange
            var target = new IdentifyActiveItemsService();
            var menu = new Menu()
            {
                Items = new List<Item>
                {
                    new Item()
                    {
                        DisplayName = "1",
                        Path = new Path{ Value = "/1"},
                        SubMenu = new SubMenu
                        {
                            Items = new List<Item>
                            {
                                new Item()
                                {
                                    DisplayName = "1.1",
                                    Path = new Path { Value = "/1/1.1"}
                                },
                                new Item()
                                {
                                    DisplayName = "1.2",
                                    Path = new Path { Value = "/1/1.2"}
                                }
                            }
                        }
                    },
                    new Item()
                    {
                        DisplayName = "2",
                        Path = new Path { Value = "/2" }
                    }
                }
            };

            // Act
            target.MarkActive(menu, "/1/1.2");

            // Assert
            Assert.AreEqual(true, menu.Items[0].SubMenu.Items[1].Active, "Target item should be active");
            Assert.AreEqual(true, menu.Items[0].Active, "Parent should be active");
        }
    }
}
