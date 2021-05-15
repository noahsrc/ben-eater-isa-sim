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
 * This class creates the simulated memory
 * and CPU to run programs on. The CPU uses
 * Ben Eater's instruction set used in his
 * 8-bit breadboard computer seen on YouTube.
 * A sample fibonacci program is typed in
 * the program workspace. Program information
 * may be seen in the program output textox at
 * the bottom of the form.
 * 
 * "Constant" variables may be set in the
 * form textboxes on the right.
 */

//
// Note: This form application is not yet
//       complete. The finished version
//       will transition the information
//       from the debug console into a
//       graphical Windows form.
//

/*
 * Update (15 May 2021):
 * 
 * Began work on the graphical form window.
 * -- Added workspace to create programs
 * -- Added program output display
 * -- Added output register display
 * -- Added run and stop button for thread control
 * -- Added textboxes for "constant" input
 * 
 * Changed cpu to run program in a new thread.
 */

using System;
using System.Threading;
using System.Windows.Forms;

namespace eaterIsaSim
{
    public partial class Form1 : Form
    {
        // Maximum bytes in memory
        // Default is 16 bytes
        private uint MAX_BYTES;

        // Program to be executed
        private uint[] pgm;

        // Ram and registers
        private Memory mem;

        // Simulated instruction set to run pgm
        private EaterIsa cpu;

        // Thread to run simulation on
        Thread sim;

        // Constructor
        public Form1()
        {
            InitializeComponent();

            sim = null;
        }

        // Called on run button click
        // 1. Assembles program (exits if error)
        // 2. Reads "constant" variables from textboxes
        // 3. Allocates new memory
        // 4. Creates cpu object with memory reference and constants
        // 5. Runs program on new thread
        private void RunProgram_Click(object sender, EventArgs e)
        {
            // Do not allow run to be clicked if program running
            if (sim != null)
            {
                return;
            }

            ProgramOutput.Clear();

            // Maximum number of bytes in memory
            MAX_BYTES = UInt32.Parse(MaxBytesTB.Text);

            // Assembles program
            // Displays error message and returns if unsuccessful
            if (!Assembler.Assemble(ProgramData.Lines, MAX_BYTES))
            {
                ProgramOutput.Text = Assembler.GetAsmInfo();
                ProgramOutput.Text += Environment.NewLine + "Could not assemble program.";
                return;
            }

            // Load program from assembler
            pgm = Assembler.GetProgram();

            ProgramOutput.Text = "Program assembled successfully. " + (MAX_BYTES - Assembler.GetBytesUsed()) + " bytes free." + Environment.NewLine;

            // How many instructions to execute before termination
            int insnCount = Int32.Parse(MaxInsnsTB.Text);

            // Delay in milliseconds between each instruction
            int delay = Int32.Parse(InsnDelayTB.Text);

            // Create new memory for the CPU
            // Initialize it with the created program
            // and max ram address space
            mem = new Memory(pgm, MAX_BYTES);

            // Create a new cpu simulation
            // Initialize it with the created memory
            cpu = new EaterIsa(ref mem, ref OutputRegTB, insnCount, delay);

            // Create new thread for program
            // This allows user to still use buttons
            // and text areas
            sim = new Thread(start);

            // Execute the program on a new thread
            sim.Start();

            sim = null;
        }

        // Stop button handler
        // Terminates the program early
        private void StopProgram_Click(object sender, EventArgs e)
        {
            if (sim != null)
            {
                cpu.Terminate();
                sim = null;
            }
        }

        // Called by sim thread to run program
        private void start()
        {
            cpu.Run(ProgramOutput);
        }
    }
}
