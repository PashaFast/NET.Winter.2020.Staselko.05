using NUnit.Framework;
using System;
using static FilterArray.ArrayExtension;
using static ArrayCreation.ArrayGenerator;

namespace FilterArray.Tests
{
    public class ArrayExtensionTests
    {
        #region FilterArrayByKey(int[]array, int digit)

        [TestCase(new[] { 2212332, 1405644, 1236674 }, 0, new[] { 1405644 })]
        [TestCase(new[] { 53, 71, -24, 1001, 32, 1005 }, 2, new[] { -24, 32 })]
        [TestCase(new[] { -27, 173, 371132, 7556, 7243, 10017 }, 7, new[] { -27, 173, 371132, 7556, 7243, 10017 })]
        [TestCase(new[] { 7, 2, 5, 5, -1, -1, 2 }, 9, new int[0])]

        public void FilterArrayByKey_WithPossitivePowers_ExpectedResults(int[] array, int digit, int[] expected)
        {
            Assert.AreEqual(expected, FilterArrayByKey(array,digit));
        }

        [Test]
        public void FilterArrayByKey_WithEmptyArray_ArgumentException() =>
           Assert.Throws<ArgumentException>(() => FilterArrayByKey(new int[0], 0),
               message: "Array cannot be empty!");

        [Test]
        public void FilterArrayByKey_WithNullArray_ArgumentNullException() =>
          Assert.Throws<ArgumentNullException>(() => FilterArrayByKey(null, 0),
              message: "Array cannot be null");

        [Test]
        public void FilterArrayByKey_WithNegativeDigit_ArgumentOutOfRangeException() =>
         Assert.Throws<ArgumentOutOfRangeException>(() => FilterArrayByKey(new int[] { 1, 2 }, -1),
             message: "Digit cannot be negative");

        [TestCase(4)]
        public void FilterArrayByKey_BigArray_Somethig(int key)
        {
            int[] source = GetArrayWithDigit(100_000_000, key);
            int[] act = FilterArrayByKey(source, key);
            Assert.AreEqual(source, act);
        }
        #endregion
        #region FilterArrayByKey(int[] array)

        [TestCase(new[] { 11111, 10001, 256 }, new[] { 11111, 10001})]
        [TestCase(new[] { 2,3,4,5 },  new[] { 2, 3, 4, 5 })]
        [TestCase(new[] { 10101, 101101 }, new[] { 10101, 101101 })]
        [TestCase(new[] { 145, 58, 78, 89 }, new int[0])]

        public void FilterArrayByKey_WithPossitivePowers_ExpectedResults(int[] array, int[] expected)
        {
            Assert.AreEqual(expected, FilterArrayByKey(array));
        }

        [Test]
        public void FilterArrayByKey_WithEmptyArray_ReturnsArgumentException() =>
           Assert.Throws<ArgumentException>(() => FilterArrayByKey(new int[0]),
               message: "Array cannot be empty!");

        [Test]
        public void FilterArrayByKey_WithNullArray_ReturnsArgumentNullException() =>
          Assert.Throws<ArgumentNullException>(() => FilterArrayByKey(null, 0),
              message: "Array cannot be null");

        [TestCase(8)]
        public void FilterArrayByKey_BigArray_ReturnSomethig(int key)
        {
            int[] source = GetArrayWithDigit(100_000_000, key);
            int[] act = FilterArrayByKey(source);
            Assert.AreEqual(source, act);
        }

        #endregion
    }
}