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
 * This class simulates a memory module with
 * the specified size of MAX_BYTES set
 * with the constructor. Default is 16 bytes.
 * 
 * This class also simulates 2 registers.
 * Register A and OUT.
 * 
 * All memory locations are read and write.
 * The constructor loads in 'pgm', a written
 * program containing instructions, and
 * saves it in memory. If the program is
 * shorter than the length of total memory,
 * the remaining bytes will be set to 0x00,
 * no operation. This also checks to make
 * sure addresses are in range when a read
 * or write operation is called.
 */

namespace eaterIsaSim
{
    class Memory
    {
        // Address space of RAM
        private uint MAX_BYTES;

        // Ram contents
        private uint[] ram;

        // A register contents
        private uint registerA;

        // Output register contents
        private uint registerOut;

        // Constructor
        // pgm : Program to load into memory
        // space : Address space of memory module
        public Memory(uint[] pgm, uint space)
        {
            // Set memory module address space
            MAX_BYTES = space;

            // Allocate memory for RAM
            ram = new uint[MAX_BYTES];

            // Initialize RAM
            for (int i = 0; i < ram.Length; i++)
            {
                // Fill ram with program contents
                // else fill with 0s if pgm shorter
                if (i < pgm.Length)
                {
                    ram[i] = pgm[i];
                }
                else
                {
                    ram[i] = 0x00;
                }
            }

            // Initialize registers
            registerA = 0x00;
            registerOut = 0x00;
        }

        // Check if memory address is valid
        private bool CheckAddress(uint addr)
        {
            // Return value at RAM address if within range
            if (addr >= 0x0 && addr < MAX_BYTES)
            {
                return true;
            }

            // Invalid address
            return false;
        }

        // Getter and setter for register A
        public uint RegA
        {
            get { return registerA; }
            set { registerA = value; }
        }

        // Getter and setter for output register
        public uint RegOut
        {
            get { return registerOut; }
            set { registerOut = value; }
        }

        // Getter for specified RAM address
        public uint GetRamAt(uint addr)
        {
            // Return value at RAM address if within range
            if (CheckAddress(addr))
            {
                return ram[addr];
            }

            // Invalid memory address
            return 0x00;
        }

        // Setter for specified RAM address
        public bool SetRamAt(uint addr, uint value)
        {
            // Set value at RAM address if within range
            if (CheckAddress(addr))
            {
                ram[addr] = value;
                return true;
            }

            // Invalid memory address
            return false;
        }

        // Return the amount of RAM address space
        public uint GetRamSpace()
        {
            return MAX_BYTES;
        }
    }
}
