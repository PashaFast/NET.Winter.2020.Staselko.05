using System;

namespace NumbersExtension
{
    /// <summary>
    /// Class NumbersExtension.
    /// </summary>
    public static class NumbersExtension
    {
        /// <summary>
        /// Algorithm of inserting bits from one number to another number.
        /// </summary>
        /// <param name="numberSource">Number for inserting bits.</param>
        /// <param name="numberIn">Number from which will get bits.</param>
        /// <param name="i">First position of inserting of bits in number.</param>
        /// <param name="j">Last position of inserting of bits in number.</param>
        /// <exception cref="ArgumentOutOfRangeException">Throw when index more than 32 or negative.</exception>
        /// <exception cref="ArgumentException">Throw when firstBit more than lastBit.</exception>
        /// <returns>Number with inserted bits.</returns>
        public static int InsertNumberIntoAnother(int numberSource, int numberIn, int i, int j)
        {
            if (i < 0 || j < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(i), " must be positive");
            }

            if (i >= 32 || j >= 32)
            {
                throw new ArgumentOutOfRangeException(nameof(j), nameof(i), "must be less than 32");
            }

            if (i > j)
            {
                throw new ArgumentException("firstBit must be less than lastBit");
            }

            int count = j - i + 1;
            int temp = 1;
            int bitMaskTemp = 0;
            while (count > 0)
            {
                bitMaskTemp |= bitMaskTemp | temp;
                temp <<= 1;
                count--;
            }

            int bitMask1 = bitMaskTemp & numberIn;
            bitMask1 <<= i;

            int bitMask2 = ~(bitMaskTemp << i);
            return (numberSource & bitMask2) | bitMask1;
        }

        /// <summary>
        /// The method determines if the number is a palindrome.
        /// </summary>
        /// <param name="number">The number that we want to check on the palindrome.</param>
        /// <exception cref="ArgumentOutOfRangeException">Throw when number is negative.</exception>
        /// <returns>True-if the numer is palindrom, false - otherwise.</returns>
        public static bool IsPalindrome(int number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(number), "cannot be negative");
            }

            int temp = Reverse(number, 0);

            if (temp == number)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static int Reverse(int n, int temp)
        {
            if (n == 0)
            {
                return temp;
            }

            temp = (temp * 10) + (n % 10);

            return Reverse(n / 10, temp);
        }
    }
}
