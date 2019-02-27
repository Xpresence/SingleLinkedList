using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SingleLinkedList;

namespace UnitTestSingleLinkedList
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestSingleLinkedList_Add()
        {
            var list = new SingleLinkedList<int>();

            Assert.IsTrue(list.IsEmpty == true);
            Assert.IsTrue(list.Count == 0);

            list.Add(0);

            Assert.IsTrue(list.Count == 1 && list[0] == 0);
            //Assert.IsTrue(list.Count == 1);
        }

        [TestMethod]
        public void TestSingleLinkedList_AppendFirst()
        {
            var list = new SingleLinkedList<int>();

            list.Add(0);

            Assert.IsTrue(list.Count == 1);
            Assert.IsTrue(list[0] == 0);

            list.AppendFirst(17);

            Assert.IsTrue(list.Count == 2);
            Assert.IsTrue(list[0] == 17);
        }

        [TestMethod]
        public void TestSingleLinkedList_Insert()
        {
            var list = new SingleLinkedList<int>();

            list.Add(17);
            list.Insert(0, 1);

            Assert.IsTrue(list.Count == 1);

        }

        [TestMethod]
        public void TestSingleLinkedList_foreach()
        {
            var list = new SingleLinkedList<int>();

            var data = new[] { 1, 2, 3, 4, 5, 6, 7 };

            foreach (var item in data)
            {
                list.Add(item);
            }

            Assert.IsTrue(list.Count == 7);

            var index = 0;
            foreach (var item in list)
            {
                Assert.IsTrue(item == data[index++]);
            }

        }

        [TestMethod]
        public void TestSingleLinkedList_CopyTo()
        {
            var list = new SingleLinkedList<int>();

            var data = new[] { 1, 2, 3, 4, 5, 6, 7 };

            foreach (var item in data)
            {
                list.Add(item);
            }

            var newData = new int[7];

            list.CopyTo(newData, 0);

            var index = 0;
            foreach (var item in list)
            {
                Assert.IsTrue(item == newData[index++]);
            }

        }

        [TestMethod]
        public void TestSingleLinkedList_Clear()
        {
            var list = new SingleLinkedList<int>();

            var data = new[] { 1, 2, 3, 4, 5, 6, 7 };

            foreach (var item in data)
            {
                list.Add(item);
            }

            var index = 0;
            foreach (var item in list)
            {
                Assert.IsTrue(item == data[index++]);
            }

            list.Clear();

            Assert.IsTrue(list.Count == 0);

        }

        [TestMethod]
        public void TestSingleLinkedList_IndexOf()
        {
            var list = new SingleLinkedList<int>();

            var data = new[] { 1, 2, 3, 4, 5, 6, 7 };

            foreach (var item in data)
            {
                list.Add(item);
            }

            Assert.IsTrue(list.IndexOf(10) == -1);
            Assert.IsTrue(list.IndexOf(1) == 0);

        }

        [TestMethod]
        public void TestSingleLinkedList_Contains()
        {
            var list = new SingleLinkedList<int>();
            
            var data = new[] { 1, 2, 3, 4, 5, 6, 7 };

            foreach (var item in data)
            {
                list.Add(item);
            }

            Assert.IsTrue(!list.Contains(17));
            Assert.IsTrue(list.Contains(3));

        }

        [TestMethod]
        public void TestSingleLinkedList_Remove()
        {
            var list = new SingleLinkedList<int>();

            var data = new[] { 1, 2, 3, 4, 5, 6, 7 };

            foreach (var item in data)
            {
                list.Add(item);
            }

            list.Remove(2);
            Assert.IsTrue(!list.Contains(2));

        }

        [TestMethod]
        public void TestSingleLinkedList_RemoveAt()
        {
            var list = new SingleLinkedList<int>();

            var data = new[] { 1, 2, 3, 4, 5, 6, 7 };

            foreach (var item in data)
            {
                list.Add(item);
            }

            list.RemoveAt(2);
            Assert.IsTrue(!list.Contains(3));

        }
    }
}