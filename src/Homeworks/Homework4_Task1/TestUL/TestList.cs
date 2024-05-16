namespace TestList
{
    using Microsoft.VisualStudio.TestPlatform.Common.DataCollection;
    using NUnit.Framework;
    using UniqueList;

    public class Tests
    {
        private MyList<int> emptyList;
        private MyList<int> list;
        private UniqueList<int> uniqList;

        [SetUp]
        public void Setup()
        {
            emptyList = new MyList<int>();
            list = new MyList<int>() {5, 6, 7, 8, 9};
            uniqList = new UniqueList<int>() {5, 6, 7, 8, 9};
        }

        private bool IsEqual(MyList<int> list, int[] expected)
        {
            if (expected.Length != list.Size)
            {
                return false;
            }

            for (var i = 0; i < list.Size; ++i)
            {
                if (list[i] != expected[i])
                {
                    return false;
                }
            }

            return true;
        }
        
        [TestCase(5, 6, 7, 8, 9)]
        public void RightAddAndSize_MyList_WithElements(params int[] expected)
        {
            foreach (var element in expected)
            {
                emptyList.Add(element);
            }

            Assert.That(IsEqual(emptyList, expected));
            Assert.That(emptyList.Size == expected.Length);
        }

        [TestCase(38, 5, 6, 55, 7, 8, 23, 9)]
        public void RightInsertAndRightInput_MyList_WithInsertion(params int[] expected)
        {
            list.Insert(0, 38);
            list.Insert(3, 55);
            list.Insert(6, 23);

            Assert.That(IsEqual(list, expected));
        }

        [TestCase(6, 8, 9)]
        public void RightRemoveAndRightInput_MyList_WithRemoval(params int[] expected)
        {
            list.Remove(2);
            list.Remove(0);

            Assert.That(IsEqual(list, expected));
        }

        [TestCase(23, 6, 7, 8, 38)]
        public void RightChange_MyList_WithChanges(params int[] expected)
        {
            list.Change(0, 23);
            list.Change(4, 38);

            Assert.That(IsEqual(list, expected));
        }

        [TestCase(5, 6, 7, 8, 9)]
        public void RightGetValue_MyList_WithValues(params int[] array)
        {
            var expected = true;
            for (var i = 0; i < list.Size; ++i)
            {
                if (list.GetValue(i) != array[i])
                {
                    expected = false;
                }
            }

            Assert.That(expected);
        }

        [TestCase(5, 6, 7, 8, 9)]
        public void RightIndex_MyList_WithElements(params int[] array)
        {
            var expected = true;
            for (var i = 0; i < list.Size; ++i)
            {
                if (list[i] != array[i])
                {
                    expected = false;
                }
            }
            Assert.That(expected);
        }

        [TestCase(7, true)]
        [TestCase(22, false)]
        public void RightContain_UniqueList_WithElements(int element, bool expected)
        {
            var result = uniqList.Contains(element);

            Assert.That(result == expected);
        }

        [Test]
        public void IndexOutOfRange_Remove_ThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Remove(-1));
        }

        [Test]
        public void InvalidRemoveFromEmptyList_ThrowException()
        {
            Assert.Throws<InvalidRemoveOperationException>(() => emptyList.Remove(0));
        }

        [Test]
        public void InvalidChangeIncorrectIndex_ThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Change(-3, 23));
        }

        [Test]
        public void InsertElementThrowException_ThrowException()
        {
            Assert.Throws<InvalidInsertOperationException>(() => uniqList.Insert(0, 5));
        }

        [Test]
        public void AddElementThrowException_ThrowException()
        {
            Assert.Throws<InvalidAddOperationException>(() => uniqList.Add(9));
        }

        [Test]
        public void ChangeElementThrowException_ThrowException()
        {
            Assert.Throws<InvalidChangeOperationException>(() => uniqList.Change(3, 8));
        }
    }
}