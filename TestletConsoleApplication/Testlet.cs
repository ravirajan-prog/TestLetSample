using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWithTestlet
{
    public class Item
    {
        public string ItemId { get; set; }
        public ItemTypeEnum ItemType { get; set; }
    }
    public class Testlet : Item
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
            foreach (var item in randomitems)
            {
                Console.WriteLine(item.ItemType);
            }
            return randomitems;

        }
    }
}
