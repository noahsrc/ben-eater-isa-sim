/*
 * Written by Noah Miller
 * 14 May 2021
 * 
 * My GitHub: https://github.com/noahsrc
 * My YouTube: https://www.youtube.com/c/noahsrc
 * 
 * Ben Eater's GitHub: https://github.com/beneater
 * Ben Eater's Youtube: https://www.youtube.com/user/eaterbc
 * 
 * This class returns the lower or
 * higher nibble of a byte from the
 * specified value.
 */

/*
 * Update (15 May 2021):
 * 
 * Added new method SetHighNibble.
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

        // Sets higher 4 bits of value
        public static uint SetHighNibble(uint value, uint nibble)
        {
            // Set mask
            value |= 0xF << 4;
            return value &= nibble << 4;
        }
    }
}
