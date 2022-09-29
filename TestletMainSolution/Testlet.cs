using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestletMainSolution
{
    public class Testlet
    {
        public string TestletId;
        private List<Item> Items;

        public Testlet(string testletId, List<Item> items)
        {
            TestletId = testletId;
            Items = items;
        }
        public List<Item> Randomize()
        {
            List<Item> randomitems = new List<Item>();
            if (Items != null && Items.Any())
            {
                var pretestItems = Items.Where(e => e.ItemType == ItemTypeEnum.Pretest).OrderBy(p => Guid.NewGuid()).Take(2).ToList();
                randomitems.AddRange(pretestItems);

                var allItems = Items.Where(e => !pretestItems.Any(p => p.ItemId == e.ItemId)).OrderBy(a => Guid.NewGuid());
                randomitems.AddRange(allItems);
            }
            Console.WriteLine(randomitems);
            return randomitems;
        }
    }
    public class Item
    {
        public string ItemId;
        public ItemTypeEnum ItemType;
    }
    public enum ItemTypeEnum
    {
        Pretest = 0,
        Operational = 1
    }
}
