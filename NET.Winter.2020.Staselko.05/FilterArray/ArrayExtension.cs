using System;
using System.Collections.Generic;
using static NumbersExtension.NumbersExtension;

namespace FilterArray
{
    /// <summary>
    /// Class ArrayExtension.
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// A method that takes an array of integers
        /// and filters it so that the output will be a new array consisting of only elements that contain a given digit.
        /// </summary>
        /// <param name="array">Input array.</param>
        /// <param name="digit">The digit by which we will filter.</param>
        /// <returns>A new array consisting only of elements that contain a given digit.</returns>
        /// <exception cref="ArgumentException">Throw when array is empty.</exception>
        /// <exception cref="ArgumentNullException">Throw when array is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Throw when digit is negative.</exception>
        public static int[] FilterArrayByKey(int[] array, int digit)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Array cannot be null");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Array cannot be empty!");
            }

            if (digit < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(digit), "Digit cannot be negative");
            }

            List<int> numbers = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (IsDigitPresent(Math.Abs(array[i]), digit))
                {
                    numbers.Add(array[i]);
                }
            }

            return numbers.ToArray();
        }

        /// <summary>
        /// A method that takes an array of integers
        /// and filters it so that the output will be a new array consisting of only elements that are palindromes.
        /// </summary>
        /// <param name="array">Input array.</param>
        /// <returns>A new array consisting of only elements that are palindromes.</returns>
        /// <exception cref="ArgumentException">Throw when array is empty.</exception>
        /// <exception cref="ArgumentNullException">Throw when array is null.</exception>
        public static int[] FilterArrayByKey(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Array cannot be null");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Array cannot be empty!");
            }

            List<int> numbers = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (IsPalindrome(array[i]))
                {
                    numbers.Add(array[i]);
                }
            }

            return numbers.ToArray();
        }

        private static bool IsDigitPresent(int number, int digit)
        {
            while (number > 0)
            {
                if (number % 10 == digit)
                {
                    return true;
                }

                number /= 10;
            }

            return false;
        }
    }
}
