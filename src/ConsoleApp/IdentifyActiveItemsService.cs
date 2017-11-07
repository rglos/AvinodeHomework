using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class IdentifyActiveItemsService
    {
        // Ah... treenode searching...
        // It feels like we should try some LINQ using SelectMany or yield return - let's get something working first 
        // and then if we have time we can iterate over it.
        //
        // We could again have an Interface and different implementations (IdentifyActiveItemsUsingLINQService, IdentifyActiveItemsUsingRecusiveService, etc)
        // and then get some performance on each implementation.
        //
        // I guess it depends on how large these menu.xml files are going to be - my guess is a menu isn't that
        // big so let's just use KISS for maintenance reasons?

        public void MarkActive(Menu menu, string pathToMatch)
        {
            foreach (var item in menu.Items)
            {
                CheckAndMarkActive(item, pathToMatch, new List<Item>());
            }
        }

        private void CheckAndMarkActive(Item item, string pathToMatch, List<Item> parents)
        {
            if (item.Path.Value.Equals(pathToMatch))
            {
                item.Active = true;
                // We need a way to mark the parents active as well - for now instead of traversing some fancy ancenstor(s) property
                // let's just have a List<> of parents by ref we can use
                foreach (var parent in parents)
                {
                    parent.Active = true;
                }
            }

            if (item.SubMenu != null)
            {
                foreach (var subMenuItem in item.SubMenu.Items)
                {
                    parents.Add(item); // add our parent to the list of parents and pass it into the method below
                    CheckAndMarkActive(subMenuItem, pathToMatch, parents);
                }
            }
        }
    }
}
