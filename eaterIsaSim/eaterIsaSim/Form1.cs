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
 * This class creates the simulated memory
 * and CPU to run programs on. The CPU uses
 * Ben Eater's instruction set used in his
 * 8-bit breadboard computer seen on YouTube.
 * A sample fibonacci program is typed in
 * the Form1 constructor using this ISA.
 * Executed instructions may be seen in the
 * debug screen.
 * 
 * Programs are by default 16
 * bytes, but this may be adjusted with
 * RAM_ADDR_SPACE. Address width should be
 * specified in hex. More information is
 * included in the Memory class.
 */

//
// Note: This form application is not yet
//       complete. The finished version
//       will transition the information
//       from the debug console into a
//       graphical Windows form.
//


using System.Windows.Forms;

namespace eaterIsaSim
{
    public partial class Form1 : Form
    {
        // Maximum address space in memory
        private const uint RAM_ADDR_SPACE = 0xF;

        // Program to be executed
        private uint[] pgm;

        // Ram and registers
        private Memory mem;

        // Simulated instruction set to run pgm
        private EaterIsa cpu;

        public Form1()
        {
            InitializeComponent();

            pgm = new uint[RAM_ADDR_SPACE];

            // Sample fibonacci sequence program
            pgm[0] = 0x51; //ldi
            pgm[1] = 0x4E; //sta
            pgm[2] = 0x51; //ldi
            pgm[3] = 0xED; //out
            pgm[4] = 0x2E; //add
            pgm[5] = 0x4F; //sta
            pgm[6] = 0x1E; //lda
            pgm[7] = 0x4D; //sta
            pgm[8] = 0x1F; //lda
            pgm[9] = 0x4E; //sta
            pgm[10] = 0x1D; //lda
            pgm[11] = 0x70; //jc
            pgm[12] = 0x63; //jmp

            // Create new memory for the CPU
            // Initialize it with the created program
            // and max ram address space
            mem = new Memory(pgm, RAM_ADDR_SPACE);

            // Create a new cpu simulation
            // Initialize it with the created memory
            cpu = new EaterIsa(ref mem);

            // Execute the program
            cpu.Run();
        }
    }
}
