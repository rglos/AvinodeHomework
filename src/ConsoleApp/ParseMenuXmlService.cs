using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp
{
    public class ParseMenuXmlService
    {
        // we could do this a few different ways
        //   - XDocument.Load("path") and then manually parse it into a nice object
        //   - I'm choosing objects that closely match the XML document to save time
        //   - We could have an interface, IParseMenuXmlService and have different implementations
        //      (ParseMenuManuallyXmlService, ParseMenuWithSerializationXmlService, ParseManuUsingABCService, etc),
        //      of how to parse that XML...

        public Menu ReadMenu(string path)
        {
            //// First attempt - we can use XPath to select an element but then we are manually parsing XML...
            //var menu = System.Xml.Linq.XDocument.Load(args[0]);
            //var element = menu.XPathSelectElement($"//path[@value='{args[1]}']");
            //var parentElement = element.Parent; // ugh..

            //// Second attempt - let's deserialize the xml into an object
            // returning a object is nice because later because longer term maintenance will be easier and hopefully the code is more clear and easy to read

            Menu menu;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Menu));
            using (var fileStream = new System.IO.FileStream(path, System.IO.FileMode.Open))
            {
                menu = (Menu)xmlSerializer.Deserialize(fileStream);
            }
            return menu;
        }
    }

    [XmlRoot(ElementName = "menu")]
    public class Menu
    {
        [XmlElement(ElementName = "item")]
        public List<Item> Items { get; set; }
    }

    public class Item
    {
        [XmlElement(ElementName = "displayName")]
        public string DisplayName { get; set; }
        [XmlElement(ElementName = "path")]
        public Path Path { get; set; }
        [XmlElement(ElementName = "subMenu")]
        public SubMenu SubMenu { get; set; }
        public bool Active { get; set; }
    }

    public class Path
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    public class SubMenu
    {
        [XmlElement(ElementName = "item")]
        public List<Item> Items { get; set; }
    }
}
