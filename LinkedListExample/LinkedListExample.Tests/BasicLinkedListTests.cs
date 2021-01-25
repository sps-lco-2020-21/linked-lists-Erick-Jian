using System;
using LinkedListExample.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedListExample.Tests
{
    [TestClass]
    public class BasicLinkedListTests
    {
        [TestMethod]
        public void TestCount()
        {
            var ill = new IntegerLinkedList(5);     // the linked list is POINTING AT the first item.
            ill.Append(7);                          // 1st item is pointing to the second
            ill.Append(9);                          // 2nd pointing to the third
            Assert.AreEqual(3, ill.Count);
            // Assert.AreEqual(ActualCountNum, linkedlist.Count)
            /*      Throws an exception if the two objects are not equal. 
             *      Different numeric types are treated as unequal even if the logical values are equal. */
        }

        [TestMethod]
        public void TestSum()
        {
            var ill = new IntegerLinkedList(5);     // declare a variable type as linked list
            ill.Append(7);
            ill.Append(9);
            ill.Remove(9);
            ill.Delete(7);                          // Boolean Output
            Assert.AreEqual(5, ill.Sum);
        }

        [TestMethod]
        public void TestToStringExplicit()
        {
            var ill = new IntegerLinkedList(5);
            ill.Append(7);
            ill.Append(9);
            Assert.AreEqual("{5, 7, 9}", ill.ToString());
        }

        [TestMethod]
        public void TestDuplicates()
        {
            var ill = new IntegerLinkedList(5);
            ill.Append(1);
            ill.Append(2);
            ill.Append(3);
            ill.Append(2);
            Assert.AreEqual("Duplicates Removed", ill.RemoveDup());
        }

        [TestMethod]
        public void TestAltMerge()
        {
            var ill = new IntegerLinkedList(1);
            var ill2 = new IntegerLinkedList(2);
            ill.Append(3);
            ill2.Append(4);
            ill.Append(5);
            ill2.Append(6);
            var ill3 = ill.AltMerge(ill2);
            Assert.AreEqual("{1, 2, 3, 4, 5, 6}",ill3.ToString());
        }


    }
}
