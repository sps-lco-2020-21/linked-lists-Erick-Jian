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
            ill.Remove(9);                          //
            Assert.AreEqual(21, ill.Sum);
        }

        [TestMethod]
        public void TestToStringExplicit()
        {
            var ill = new IntegerLinkedList(5);
            ill.Append(7);
            ill.Append(9);
            Assert.AreEqual("{5, 7, 9}", ill.ToString());
        }

    }
}
