﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWithTestlet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testlet Project!");


            var testlet = new List<Item>() {
                new Item(){ ItemId = "1", ItemType = ItemTypeEnum.Operational},
                new Item(){ ItemId = "2", ItemType = ItemTypeEnum.Operational},
                new Item(){ ItemId = "3", ItemType = ItemTypeEnum.Operational},
                new Item(){ ItemId = "4", ItemType = ItemTypeEnum.Operational},
                new Item(){ ItemId = "5", ItemType = ItemTypeEnum.Operational},
                new Item(){ ItemId = "6", ItemType = ItemTypeEnum.Operational},
                new Item(){ ItemId = "7", ItemType = ItemTypeEnum.Pretest},
                new Item(){ ItemId = "8", ItemType = ItemTypeEnum.Pretest},
                new Item(){ ItemId = "9", ItemType = ItemTypeEnum.Pretest},
                new Item(){ ItemId = "10", ItemType = ItemTypeEnum.Pretest}
            };
            Testlet ob = new Testlet("1", testlet);
            ob.Randomize();
            Console.ReadLine();
        }
    }

    public enum ItemTypeEnum
    {
        Pretest = 0,
        Operational = 1
    }
}
