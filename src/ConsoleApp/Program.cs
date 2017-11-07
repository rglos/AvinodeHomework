using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace ConsoleApp
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var stopwatch = Stopwatch.StartNew();
            Trace.WriteLine("Main - start");

            // Thoughts... we could solve this a few ways
            // 1. As we are parsing the XML using XDocument or XmlReader, we could be identifying active menu items.  In real world though we wouldn't probably read the xml every single time, it would be cached and we'd just find active menu items using previously parsed xml
            // 2. Parse the XML or deserialize it into an object, then recurse or LINQ? to find the nodes that match
            // 3. Use the XML directly instead of parsing into an object
            // 4. Which is fastest - also depends on size of the xml file...

            // #1 - Accept 2 arguments
            if (args.Length != 2)
            {
                Console.WriteLine("Expected 2 arguments.");
                Console.WriteLine("Usage: ConsoleApp.exe \"c:\\path\\to\\menu.xml\" \"/menu/item/path\" ");
                return 1;
            }

            // #2 - Parse XML
            var parseMenuXmlService = new ParseMenuXmlService();
            var menu = parseMenuXmlService.ReadMenu(args[0]);

            // #3 - Identify currently-active menu item[s]
            var identifyActiveItemsService = new IdentifyActiveItemsService();
            identifyActiveItemsService.MarkActive(menu, args[1]);

            // #4 - Write parsed menu to console
            foreach (var item in menu.Items)
            {
                WriteItemToConsole(item, 0);
            }

            stopwatch.Stop();
            Trace.WriteLine($"Main - complete, Elapsed: {stopwatch.Elapsed}");

            return 0;
        }

        private static void WriteItemToConsole(Item item, int depth)
        {
            var leftPadding = string.Empty.PadLeft(depth * 4);
            Console.WriteLine($"{leftPadding}{item.DisplayName}, {item.Path.Value} {(item.Active ? "ACTIVE" : string.Empty)}");
            if (item.SubMenu != null)
            {
                foreach (var subMenuItem in item.SubMenu.Items)
                {
                    WriteItemToConsole(subMenuItem, depth + 1);
                }
            }
        }
    }


}
