/*
 * Written by Noah Miller
 * 15 May 2021
 * 
 * My GitHub: https://github.com/noahsrc
 * My YouTube: https://www.youtube.com/c/noahsrc
 * 
 * Ben Eater's GitHub: https://github.com/beneater
 * Ben Eater's Youtube: https://www.youtube.com/user/eaterbc
 * 
 * This class assembles a program from
 * assembler to hexidecimal using Ben
 * Eater's 8-bit instruction set
 * specifications.
 * 
 * A program is sent to the Assemble method
 * and is parsed by each line. Returning true
 * means the program was successfully assembled.
 * Returning false, the opposite. Error codes
 * are posted to the string "asmInfo". If
 * returning false, the calling class will read
 * the error information using method GetAsmInfo.
 * 
 * Instruction syntax:
 * lda 3
 * LDA 3
 * lDa 3 this is a comment
 * 
 * Syntax cont.:
 * Blank lines are allowed.
 * Blank lines with spaces are allowed.
 * To comment on a non-executing line, use ;
 * as the first character.
 */

using System;
using System.Linq;

namespace eaterIsaSim
{
    public static class Assembler
    {
        // Error code if applicable
        private static string asmInfo;

        // Program data
        private static uint[] pgm;

        // Cursor location within program
        private static int count = 0;

        // Converts a line from assembler to
        // its hexadecimal value
        private static uint Parse(string line)
        {
            // Check for blank line or comment
            if (String.IsNullOrWhiteSpace(line) || line.StartsWith(";"))
            {
                // Code for blank line or comment
                return 0x0100;
            }

            // Tokenize the assembler line
            string[] tokens = line.Split(' ');

            // Initialize byte data
            uint byteData = 0x00;

            // Define opcode
            uint opCode;

            // Get opcode from assembler mnemonic
            switch (tokens[0].ToLower())
            {
                case "nop": opCode = 0x0; break;
                case "lda": opCode = 0x1; break;
                case "add": opCode = 0x2; break;
                case "sub": opCode = 0x3; break;
                case "sta": opCode = 0x4; break;
                case "ldi": opCode = 0x5; break;
                case "jmp": opCode = 0x6; break;
                case "jc":  opCode = 0x7; break;
                case "jz":  opCode = 0x8; break;
                case "out": opCode = 0xE; break;
                case "hlt": opCode = 0xF; break;
                // Error code for mnemonic not found
                default: return 0x0200;
            }

            // Check if second token exists
            if (tokens.Length == 1 || String.IsNullOrWhiteSpace(tokens[1]) || !tokens[1].All(char.IsDigit))
            {
                // Error code for register number or immediate not found
                return 0x0300;
            }

            // Check if register number or immediate is within 4 bits
            if (UInt32.Parse(tokens[1]) > 0xF)
            {
                // Error code for exceeding 4 bits
                return 0x0400;
            }

            // Returns the combination of opcode and register number or immediate
            // High nibble + low nibble = byte
            // opCode is shifted into high nibble of byteData, register number or
            // immediate is added to byteData
            return Hex.SetHighNibble(byteData, opCode) + UInt32.Parse(tokens[1]);
        }

        // Assembles an assembler program
        // Returns true on success, false
        // if not.
        public static bool Assemble(string[] data, uint MAX_BYTES)
        {
            count = 0;

            // Allocate new program
            pgm = new uint[MAX_BYTES];

            // Define parsed line
            uint parsedLine;

            // Iterate through program data and parse each line
            for (int i = 0; i < data.Length; i++)
            {
                // Convert line from assembler to hexidecimal
                parsedLine = Parse(data[i]);

                // Add line to program or post
                // error code and return
                switch(parsedLine)
                {
                    case 0x0100: // Null or whitespace
                        break;
                    case 0x0200: // Invalid opcode
                        asmInfo = "Invalid opcode found at line " + (i + 1) + ".";
                        return false;
                    case 0x0300: // No number specified
                        asmInfo = "Register number or immediate not specified at line " + (i + 1) + ".";
                        return false;
                    case 0x0400: // Number out of range
                         asmInfo = "Number out of range at line " + (i + 1) + ". Must be a value 0 to 15.";
                        return false;
                    default:
                        pgm[count] = parsedLine;
                        count++;
                        break;
                }

                // Check if program size meets or exceeds maxmum size
                if (count >= MAX_BYTES)
                {
                    asmInfo ="Maximum byte count met. Last instruction loaded at line " + (i + 1) + ".";
                    return false;
                }
            }

            // Successfully assemble
            return true;
        }

        // Returns the assebmled program
        // Called only when Assemble method
        // returns true
        public static uint[] GetProgram()
        {
            return pgm;
        }

        // Returns error code posted by
        // assembler
        public static string GetAsmInfo()
        {
            return asmInfo;
        }

        // Returns number of bytes used by program
        public static int GetBytesUsed()
        {
            return count;
        }
    }
}
