using System.Runtime.InteropServices;
using System.Text;

namespace IEEE754Format
{
    /// <summary>
    /// DoubleExtension class.
    /// </summary>
    public static class DoubleExtension
    {
        /// <summary>
        /// Extension method to get a string representation of a double number in IEEE754 format.
        /// </summary>
        /// <param name="number">Input double number.</param>
        /// <returns>A string representation of a double number in IEEE754 format.</returns>
        public static string ConvertToFORMAT754(this double number)
        {
            Converter converter = default;
            return converter.ConvertDoubleToFormatIEEE754(number);
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct Converter
        {
            [FieldOffset(0)]
            public double Number;
            [FieldOffset(0)]
            public long NumbersBitsInLongType;

            public string ConvertDoubleToFormatIEEE754(double number)
            {
                this.Number = number;
                byte oneBit;
                StringBuilder sb = new StringBuilder();
                for (int i = 63; i >= 0; i--)
                {
                    oneBit = (byte)(this.NumbersBitsInLongType >> i & 1);
                    sb.Append(oneBit);
                }

                return sb.ToString();
            }
        }
    }
}
