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
 * This class simulates the instruction set from
 * Ben Eater's 8-bit breadboard computer. There
 * are 11 instructions and space for 5 more. Call
 * run to begin the simulation. The program counter
 * starts at 0x0 and iterates through each memory
 * location in RAM until one of three conditions
 * is met:
 * 
 * -- The HLT instruction is called
 * -- The MAX_INSNS have been executed
 * -- The program counter points to invalid memory
 */

namespace eaterIsaSim
{
    class EaterIsa
    {
        // Maximum number of instructions that may be executed
        // before termination
        private const int MAX_INSNS = 500;

        // Reference to memory in Form1 class
        private Memory mem;

        // Halt flag set by HLT instruction
        // Halts program
        private bool halt;

        // Flag set when result of alu operation is 0
        private bool zeroFlag;

        // Flag set when carry but of alu is 1
        private bool carryFlag;

        // Program counter
        // Points to a memory location in RAM
        private uint pc;

        // Number if instructions executed
        private int insnCount;

        // Constructor
        public EaterIsa(ref Memory m)
        {
            mem = m;
            halt = false;
            zeroFlag = false;
            carryFlag = false;
            pc = 0x0;
            insnCount = 0;
        }

        // NO OPERATION :: 0000
        public string Nop(uint insn)
        {
            // Increment program counter
            pc += 0x1;

            return "NOP (0x" + Hex.GetHighNibble(insn).ToString("X") + ") :: No operation.";
        }

        // LOAD A :: 0001
        // Load low nibble into register A
        public string Lda(uint insn)
        {
            // Set contents of register A to specified memory location
            mem.RegA = mem.GetRamAt(Hex.GetLowNibble(insn));

            // Increment program counter 1 byte
            pc += 0x1;

            return "LDA (0x" + Hex.GetHighNibble(insn).ToString("X") + ") :: Loaded 0x" + mem.RegA.ToString("X")
                + " into register A from memory location 0x" + Hex.GetLowNibble(insn).ToString("X") + ".";
        }

        // ADD :: 0010
        // Add contents of register A and B
        // Store sum in register A
        public string Add(uint insn)
        {
            // Add contents of register A and specified memory location
            mem.RegA += mem.GetRamAt(Hex.GetLowNibble(insn));

            // Check if carry or zero flag are set after addition operation
            CheckFlags();

            pc += 0x1;

            return "ADD (0x" + Hex.GetHighNibble(insn).ToString("X") + ") :: The sum of register A and B is 0x"
                + mem.RegA.ToString("X") + ". Stored in register A.";
        }

        // SUBTRACT :: 0011
        // Subtract contents of register A from B
        // Store difference in register A
        public string Sub(uint insn)
        {
            // Subtract contents of register A and specified memory location
            mem.RegA -= mem.GetRamAt(Hex.GetLowNibble(insn));

            // Check if carry or zero flag are set after subtraction operation
            CheckFlags();

            pc += 0x1;

            return "SUB (0x" + Hex.GetHighNibble(insn).ToString("X") + ") :: The difference of register A and B is 0x"
                + mem.RegA.ToString("X") + ". Stored in register A.";
        }

        // STORE A :: 0100
        // Store contents of register A into memory
        public string Sta(uint insn)
        {
            // Store contents of register A in specified memory location
            mem.SetRamAt(Hex.GetLowNibble(insn), mem.RegA);

            pc += 0x1;

            return "STA (0x" + Hex.GetHighNibble(insn).ToString("X") + ") :: Stored 0x" + mem.RegA.ToString("X") + " at location 0x"
                + Hex.GetLowNibble(insn).ToString("X") + " in memory.";
        }

        // LOAD IMMEDIATE :: 0101
        // Load low nibble into register A
        public string Ldi(uint insn)
        {
            // Load lower 4 bits of specified memory location into register A
            mem.RegA = Hex.GetLowNibble(insn);

            pc += 0x1;

            return "LDI (0x" + Hex.GetHighNibble(insn).ToString("X") + ") :: Loaded immediate 0x" + mem.RegA.ToString("X")
                + " into register A.";
        }

        // JUMP :: 0110
        // Unconditional jump to memory address
        public string Jmp(uint insn)
        {
            // Set program counter to specified memory address
            pc = Hex.GetLowNibble(insn);

            return "JMP (0x" + Hex.GetHighNibble(insn).ToString("X") + ") :: Jumped to location 0x" + pc.ToString("X")
                + " in memory.";
        }

        // JUMP ON CARRY :: 0111
        // Jump to memory address if carry flag is true
        public string Jc(uint insn)
        {
            // Set program counter to specified memory address
            // if carry flag is true
            if (carryFlag)
            {
                pc = Hex.GetLowNibble(insn);

                return "JC (0x" + Hex.GetHighNibble(insn).ToString("X") + ") :: Carry true. Jumped to location 0x"
                    + pc.ToString("X") + " in memory.";
            }

            // Increment program counter if carry flag is false
            pc += 0x1;

            return "JC (0x" + Hex.GetHighNibble(insn).ToString("X") + ") :: Carry false. Did not jump to 0x"
                + Hex.GetLowNibble(insn).ToString("X") + " in memory.";
        }

        // JUMP ON ZERO :: 1000
        // Jump to memory address if zero flag is true
        public string Jz(uint insn)
        {
            // Set program counter to specified memory address
            // if zero flag is true
            if (zeroFlag)
            {
                pc = Hex.GetLowNibble(insn);
                return "JZ (0x" + Hex.GetHighNibble(insn).ToString("X") + ") :: Zero true. Jumped to location 0x"
                    + pc.ToString("X") + " in memory.";
            }

            // Increment program counter if zero flag is false
            pc += 0x1;

            return "JZ (0x" + Hex.GetHighNibble(insn).ToString("X") + ") :: Zero false. Did not jump to 0x"
                + Hex.GetLowNibble(insn).ToString("X") + " in memory.";
        }

        // OUT / DISPLAY :: 1110
        // Output contents at memory address
        public string Dsp(uint insn)
        {
            // Set output register contents to specified memory contents.
            mem.RegOut = mem.GetRamAt(Hex.GetLowNibble(insn));

            pc += 0x1;

            return "DSP (0x" + Hex.GetHighNibble(insn).ToString("X") + ") :: Displaying 0x" + mem.RegOut.ToString("X")
                + " (" + mem.RegOut + ") from memory location 0x" + Hex.GetLowNibble(insn).ToString("X") + ".";
        }

        // HALT :: 1111
        // Halt processing
        public string Hlt(uint insn)
        {
            // Mark halt flag to terminate execution
            halt = true;

            pc += 0x1;

            return "HLT (0x" + Hex.GetHighNibble(insn).ToString("X") + ") :: Program halted.";
        }

        // Called after arithmetic operation to
        // check for carry or if result equals 0
        public void CheckFlags()
        {
            // Carry is true if contents of register
            // A are greater than 255 (0xFF)
            // This is checking the 9th bit
            if (mem.RegA > 0xFF)
            {
                // Revert register A contents to only
                // contain 8 bits
                mem.RegA &= 0xFF;

                carryFlag = true;
            }
            else
            {
                carryFlag = false;
            }

            // Zero is true if contents of register
            // A are equal to 0
            if (mem.RegA == 0x0)
            {
                zeroFlag = true;
            }
            else
            {
                zeroFlag = false;
            }
        }

        // Decodes high nibble of instruction
        // and executes the specific instruction.
        private string Decode(uint insn)
        {
            switch(Hex.GetHighNibble(insn))
            {
                case 0x0: return Nop(insn); // No operation
                case 0x1: return Lda(insn); // Load A
                case 0x2: return Add(insn); // Add
                case 0x3: return Sub(insn); // Subtract
                case 0x4: return Sta(insn); // Store A
                case 0x5: return Ldi(insn); // Load immediate
                case 0x6: return Jmp(insn); // Jump
                case 0x7: return Jc(insn); // Jump carry
                case 0x8: return Jz(insn); // Jump zero
                case 0xE: return Dsp(insn); // Display / Out
                case 0xF: return Hlt(insn); // Halt
                default: return "Error. Opcode: " + Hex.GetHighNibble(insn).ToString("X") + " not found.";
            }
        }

        // Exexutes the program loaded into memory.
        // MAX_INSNS prevents an infinite loop.
        // Halt can be called by the program to terminate
        // execution.
        public void Run()
        {
            // Execute the program while within address space,
            // not halted, and less than max instructions.
            while(!halt && pc <= mem.GetRamSpace() && insnCount < MAX_INSNS)
            {
                // Execute instruction
                System.Diagnostics.Debug.WriteLine("PC (0x" + pc.ToString("X") + ") :: " + Decode(mem.GetRamAt(pc)));

                // Increment instruction count
                insnCount++;
            }

            System.Diagnostics.Debug.WriteLine("Program terminated. " + insnCount + " instructions executed.");
        }
    }
}
