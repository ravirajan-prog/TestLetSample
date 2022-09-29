using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestletMainSolution;

namespace TestletUnittest
{
    [TestClass]
    public class TestLetUnittest
    {
        List<Item> items = new List<Item>();

        [TestInitialize]
        public void Testinitialize()
        {
            items.Add(new Item() { ItemId = "1", ItemType = ItemTypeEnum.Operational });
            items.Add(new Item() { ItemId = "2", ItemType = ItemTypeEnum.Operational });
            items.Add(new Item() { ItemId = "3", ItemType = ItemTypeEnum.Operational });
            items.Add(new Item() { ItemId = "4", ItemType = ItemTypeEnum.Operational });
            items.Add(new Item() { ItemId = "5", ItemType = ItemTypeEnum.Operational });
            items.Add(new Item() { ItemId = "6", ItemType = ItemTypeEnum.Operational });
            items.Add(new Item() { ItemId = "7", ItemType = ItemTypeEnum.Pretest });
            items.Add(new Item() { ItemId = "8", ItemType = ItemTypeEnum.Pretest });
            items.Add(new Item() { ItemId = "9", ItemType = ItemTypeEnum.Pretest });
            items.Add(new Item() { ItemId = "10", ItemType = ItemTypeEnum.Pretest });
        }
        [TestMethod]
        public void TestRandomWithFirstTwoPretest()
        {
            Testlet testlet = new Testlet("1", items);
            var randomItems = testlet.Randomize();
            Assert.IsNotNull(randomItems);
            Assert.IsTrue(randomItems.Count == 10);
            Assert.IsTrue(randomItems.Take(2).All(e => e.ItemType == ItemTypeEnum.Pretest));
        }

        [TestMethod]
        public void TestRandomWithAll()
        {
            Testlet testlet = new Testlet("1", items);
            var randomItems = testlet.Randomize();
            Assert.IsNotNull(randomItems);
            Assert.IsTrue(randomItems.Count == 10);
            Assert.IsTrue(randomItems.Skip(2).All(e => e.ItemType == ItemTypeEnum.Pretest || e.ItemType == ItemTypeEnum.Operational));
        }

        [TestMethod]
        public void TestRandomWithOrderItems()
        {
            Testlet testlet = new Testlet("1", items);
            var randomItemsWithFirst = testlet.Randomize();
            var randomItemsItemsSecond = testlet.Randomize();
            Assert.IsNotNull(randomItemsWithFirst);
            Assert.IsNotNull(randomItemsItemsSecond);
            Assert.IsTrue(randomItemsWithFirst.Count == 10);
            Assert.IsTrue(randomItemsItemsSecond.Count == 10);
            Assert.IsFalse(randomItemsWithFirst.SequenceEqual(randomItemsItemsSecond));
        }
    }
}
