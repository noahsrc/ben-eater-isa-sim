/*
 * Written by Noah Miller
 * 14 May 2021
 * 
 * My GitHub: https://github.com/noahsrc
 * My YouTube: https://bit.ly/33N5vJP
 * 
 * Ben Eater's GitHub: https://github.com/beneater
 * Ben Eater's Youtube: https://bit.ly/3eMXKtH
 * 
 * This class returns the lower or
 * higher nibble of a byte from the
 * specified value.
 */

namespace eaterIsaSim
{
    public static class Hex
    {
        // Returns lower 4 bits of value
        public static uint GetLowNibble(uint value)
        {
            return value & 0x0F;
        }

        // Returns higher 4 bits of value
        public static uint GetHighNibble(uint value)
        {
            return value >> 4;
        }
    }
}
