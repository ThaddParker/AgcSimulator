using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace AgcApp
{
    public class Assembler
    {
        private string sourceProgram;
        private Hashtable labelTable;
        private int currentIndex;
        private ushort asLength;
        private bool isEnd;
        private ushort executionAddress;
        private string origin;

        private enum Registers
        {
            Unknown = 0,
            A = 4,
            B = 2,
            D = 1,
            X = 16,
            Y = 8
        }

        public Assembler()
        {
            labelTable = new Hashtable(50);
            currentIndex = 0;
            asLength = 0;
            executionAddress = 0;
            isEnd = false;
            sourceProgram = "";
            origin = "1000";
        }

        public void AssembleFromFile(string sourceFilePath)
        {
            if (!File.Exists(sourceFilePath))
                throw new FileNotFoundException();

            var destinationFileName = Path.ChangeExtension(sourceFilePath, "b32");

            asLength = Convert.ToUInt16(origin, 16);

            FileStream fs = new FileStream(destinationFileName, FileMode.Create);

            var output = new BinaryWriter(fs);


            sourceProgram = File.ReadAllText(sourceFilePath);


            output.Write((byte)'B');
            output.Write((byte)'3');

            output.Write((byte)'2');

            output.Write(Convert.ToUInt16(origin, 16));

            output.Write((ushort)0);

            Parse(output);

            output.Seek(5, SeekOrigin.Begin);
            output.Write(executionAddress);
            output.Close();
            fs.Close();
        }

        private void Parse(BinaryWriter outputFile)
        {
            currentIndex = 0;
            while (isEnd == false)
                LabelScan(outputFile, true);

            isEnd = false;
            currentIndex = 0;
            asLength = Convert.ToUInt16(origin, 16);

            while (isEnd == false)
                LabelScan(outputFile, false);
        }

        private void LabelScan(BinaryWriter outputFile, bool isLabelScan)
        {
            if (currentIndex >= sourceProgram.Length)
            {
                isEnd = true;
                return;
            }
            if (char.IsLetter(sourceProgram[currentIndex]))
            {                 // Must be a label
                if (isLabelScan)
                    labelTable.Add(GetLabelName(), asLength);
                while (sourceProgram[currentIndex] != '\n')
                    currentIndex++;
                currentIndex++;
                return;
            }
            EatWhiteSpaces();
            ReadMneumonic(outputFile, isLabelScan);
        }

        private void ReadMneumonic(BinaryWriter outputFile, bool isLabelScan)
        {
            string mneumonic = "";

            while (!(char.IsWhiteSpace(sourceProgram[currentIndex])))
            {
                mneumonic += sourceProgram[currentIndex];
                currentIndex++;
            }

            switch (mneumonic.ToUpper())
            {
                case "LDX":
                    InterpretLDX(outputFile, isLabelScan);
                    break;
                case "LDA":
                    InterpretLDA(outputFile, isLabelScan);
                    break;
                case "STA":
                    InterpretSTA(outputFile, isLabelScan);
                    break;
                case "CMPA":
                    InterpretCMPA(outputFile, isLabelScan);
                    break;
                case "CMPB":
                    InterpretCMPB(outputFile, isLabelScan);
                    break;
                case "CMPX":
                    InterpretCMPX(outputFile, isLabelScan);
                    break;
                case "CMPY":
                    InterpretCMPY(outputFile, isLabelScan);
                    break;
                case "CMPD":
                    InterpretCMPD(outputFile, isLabelScan);
                    break;
                case "JMP":
                    InterpretJMP(outputFile, isLabelScan);
                    break;
                case "JEQ":
                    InterpretJEQ(outputFile, isLabelScan);
                    break;
                case "JNE":
                    InterpretJNE(outputFile, isLabelScan);
                    break;
                case "JGT":
                    InterpretJGT(outputFile, isLabelScan);
                    break;
                case "JLT":
                    InterpretJLT(outputFile, isLabelScan);
                    break;
                case "LDY":
                    InterpretLDY(outputFile, isLabelScan);
                    break;
                case "LDB":
                    InterpretLDB(outputFile, isLabelScan);
                    break;

                case "INCA":
                    InterpretINCA(outputFile, isLabelScan);
                    break;

                case "INCB":
                    InterpretINCB(outputFile, isLabelScan);
                    break;

                case "INCX":
                    InterpretINCX(outputFile, isLabelScan);
                    break;

                case "INCY":
                    InterpretINCY(outputFile, isLabelScan);
                    break;

                case "INCD":
                    InterpretINCD(outputFile, isLabelScan);
                    break;

                case "DECA":
                    InterpretDECA(outputFile, isLabelScan);
                    break;

                case "DECB":
                    InterpretDECB(outputFile, isLabelScan);
                    break;

                case "DECX":
                    InterpretDECX(outputFile, isLabelScan);
                    break;

                case "DECY":
                    InterpretDECY(outputFile, isLabelScan);
                    break;

                case "ROLA":
                    InterpretROLA(outputFile, isLabelScan);
                    break;
                case "ROLB":
                    InterpretROLB(outputFile, isLabelScan);
                    break;
                case "RORA":
                    InterpretRORA(outputFile, isLabelScan);
                    break;
                case "RORB":
                    InterpretRORB(outputFile, isLabelScan);
                    break;
                case "ADCA":
                    InterpretADCA(outputFile, isLabelScan);
                    break;
                case "ADCB":
                    InterpretADCB(outputFile, isLabelScan);
                    break;
                case "ADDA":
                    InterpretADCA(outputFile, isLabelScan);
                    break;
                case "ADDB":
                    InterpretADCA(outputFile, isLabelScan);
                    break;
                case "ADDAB":
                    InterpretADDAB(outputFile, isLabelScan);
                    break;

                case "END":
                    isEnd = true;
                    DoEnd(outputFile, isLabelScan);
                    EatWhiteSpaces();
                    executionAddress = (ushort)labelTable[(GetLabelName())];
                    return;
            }

            while (sourceProgram[currentIndex] != '\n')
            {
                currentIndex++;
            }
            currentIndex++;
        }


        private void EatWhiteSpaces()
        {
            while (char.IsWhiteSpace(sourceProgram[currentIndex])) { currentIndex++; }
        }

        private string GetLabelName()
        {
            string lblname = "";

            while (char.IsLetterOrDigit(sourceProgram[currentIndex]))
            {
                if (sourceProgram[currentIndex] == ':') { currentIndex++; break; }

                lblname += sourceProgram[currentIndex];
                currentIndex++;
            }

            return lblname.ToUpper();
        }

        private void DoEnd(BinaryWriter outputFile, bool isLabelScan)
        {
            asLength++;
            if (!isLabelScan)
            {
                outputFile.Write((byte)0x04);

            }
        }
        private Registers ReadRegister()
        {
            switch (sourceProgram[currentIndex])
            {
                case 'X':
                case 'x':
                    currentIndex++;
                    return Registers.X;

                case 'Y':
                case 'y':
                    currentIndex++;
                    return Registers.Y;
                case 'D':
                case 'd':
                    currentIndex++;
                    return Registers.D;
                case 'A':
                case 'a':
                    currentIndex++;
                    return Registers.A;
                case 'B':
                case 'b':
                    currentIndex++;
                    return Registers.B;
                default:
                    currentIndex++;
                    return Registers.Unknown;

            }
        }
        private ushort ReadWordValue()
        {
            ushort val = 0;
            bool IsHex = false;
            string sval = "";

            if (sourceProgram[currentIndex] == '$')
            {
                currentIndex++;
                IsHex = true;
            }

            if ((IsHex == false) && (char.IsLetter(sourceProgram[currentIndex])))
            {
                val = (ushort)labelTable[GetLabelName()];
                return val;
            }
            while (char.IsLetterOrDigit(sourceProgram[currentIndex]))
            {
                sval += sourceProgram[currentIndex];
                currentIndex++;
            }

            val = IsHex ? Convert.ToUInt16(sval, 16) : ushort.Parse(sval);

            return val;
        }
        private byte ReadByteValue()
        {
            byte val = 0;
            bool IsHex = false;
            string sval = "";

            if (sourceProgram[currentIndex] == '$')
            {
                currentIndex++; IsHex = true;
            }

            while (char.IsLetterOrDigit(sourceProgram[currentIndex]))
            {
                sval += sourceProgram[currentIndex];
                currentIndex++;
            }
            val = IsHex ? Convert.ToByte(sval, 16) : byte.Parse(sval);

            return val;
        }
        private void InterpretSTA(BinaryWriter outputFile, bool isLabelScan)
        {
            EatWhiteSpaces();
            if (sourceProgram[currentIndex] == ',')
            {
                Registers r;
                byte opcode = 0x00;

                currentIndex++;
                EatWhiteSpaces();
                r = ReadRegister();
                switch (r)
                {
                    case Registers.X:
                        opcode = 0x03; break;

                }
                asLength += 1;

                if (!isLabelScan)
                {
                    outputFile.Write(opcode);

                }
            }
        }

        private void InterpretLDX(BinaryWriter outputFile, bool isLabelScan)
        {
            EatWhiteSpaces();
            if (sourceProgram[currentIndex] == '#')
            {
                currentIndex++;
                ushort val = ReadWordValue();
                asLength += 3;
                if (!isLabelScan)
                {
                    outputFile.Write((byte)0x02);

                    outputFile.Write(val);

                }
            }
        }

        private void InterpretLDA(BinaryWriter outputFile, bool isLabelScan)
        {
            EatWhiteSpaces();
            if (sourceProgram[currentIndex] == '#')
            {
                currentIndex++;
                byte val = ReadByteValue();
                asLength += 2;
                if (!isLabelScan)
                {
                    outputFile.Write((byte)0x01);

                    outputFile.Write(val);

                }
            }
        }

        private void InterpretCMPA(System.IO.BinaryWriter OutputFile, bool IsLabelScan)
        {
            EatWhiteSpaces();
            if (sourceProgram[currentIndex] == '#')
            {
                currentIndex++;
                byte val = ReadByteValue();
                asLength += 2;
                if (!IsLabelScan)
                {
                    OutputFile.Write((byte)0x05);
                    OutputFile.Write(val);
                }
            }
        }

        private void InterpretCMPB(System.IO.BinaryWriter OutputFile, bool IsLabelScan)
        {
            EatWhiteSpaces();
            if (sourceProgram[currentIndex] == '#')
            {
                currentIndex++;
                byte val = ReadByteValue();
                asLength += 2;
                if (!IsLabelScan)
                {
                    OutputFile.Write((byte)0x06);
                    OutputFile.Write(val);
                }
            }
        }

        private void InterpretCMPX(System.IO.BinaryWriter OutputFile, bool IsLabelScan)
        {
            EatWhiteSpaces();
            if (sourceProgram[currentIndex] == '#')
            {
                currentIndex++;
                ushort val = ReadWordValue();
                asLength += 3;
                if (!IsLabelScan)
                {
                    OutputFile.Write((byte)0x07);
                    OutputFile.Write(val);
                }
            }
        }

        private void InterpretCMPY(System.IO.BinaryWriter OutputFile, bool IsLabelScan)
        {
            EatWhiteSpaces();
            if (sourceProgram[currentIndex] == '#')
            {
                currentIndex++;
                ushort val = ReadWordValue();
                asLength += 3;
                if (!IsLabelScan)
                {
                    OutputFile.Write((byte)0x08);
                    OutputFile.Write(val);
                }
            }
        }

        private void InterpretCMPD(System.IO.BinaryWriter OutputFile, bool IsLabelScan)
        {
            EatWhiteSpaces();
            if (sourceProgram[currentIndex] == '#')
            {
                currentIndex++;
                ushort val = ReadWordValue();
                asLength += 3;
                if (!IsLabelScan)
                {
                    OutputFile.Write((byte)0x09);
                    OutputFile.Write(val);
                }
            }
        }

        private void InterpretJMP(System.IO.BinaryWriter OutputFile, bool IsLabelScan)
        {
            EatWhiteSpaces();
            if (sourceProgram[currentIndex] == '#')
            {
                currentIndex++;
                asLength += 3;
                if (IsLabelScan)
                    return;
                ushort val = ReadWordValue();
                if (!IsLabelScan)
                {
                    OutputFile.Write((byte)0x0A);
                    OutputFile.Write(val);
                }
            }
        }

        private void InterpretJEQ(System.IO.BinaryWriter OutputFile, bool IsLabelScan)
        {
            EatWhiteSpaces();
            if (sourceProgram[currentIndex] == '#')
            {
                currentIndex++;
                asLength += 3;
                if (IsLabelScan) return;
                ushort val = ReadWordValue();

                if (!IsLabelScan)
                {
                    OutputFile.Write((byte)0x0B);
                    OutputFile.Write(val);
                }
            }
        }

        private void InterpretJNE(System.IO.BinaryWriter OutputFile, bool IsLabelScan)
        {
            EatWhiteSpaces();
            if (sourceProgram[currentIndex] == '#')
            {
                currentIndex++;
                asLength += 3;
                if (IsLabelScan) return;
                ushort val = ReadWordValue();

                if (!IsLabelScan)
                {
                    OutputFile.Write((byte)0x0C);
                    OutputFile.Write(val);
                }
            }
        }

        private void InterpretJGT(System.IO.BinaryWriter OutputFile, bool IsLabelScan)
        {
            EatWhiteSpaces();
            if (sourceProgram[currentIndex] == '#')
            {
                currentIndex++;
                asLength += 3;
                if (IsLabelScan) return;
                ushort val = ReadWordValue();

                if (!IsLabelScan)
                {
                    OutputFile.Write((byte)0x0D);
                    OutputFile.Write(val);
                }
            }
        }

        private void InterpretJLT(System.IO.BinaryWriter OutputFile, bool IsLabelScan)
        {
            EatWhiteSpaces();
            if (sourceProgram[currentIndex] == '#')
            {
                currentIndex++;
                asLength += 3;
                if (IsLabelScan) return;
                ushort val = ReadWordValue();

                if (!IsLabelScan)
                {
                    OutputFile.Write((byte)0x0E);
                    OutputFile.Write(val);
                }
            }
        }

        private void InterpretLDB(System.IO.BinaryWriter OutputFile, bool IsLabelScan)
        {
            EatWhiteSpaces();
            if (sourceProgram[currentIndex] == '#')
            {
                currentIndex++;
                byte val = ReadByteValue();
                asLength += 2;
                if (!IsLabelScan)
                {
                    OutputFile.Write((byte)0x22);
                    OutputFile.Write(val);
                }
            }
        }

        private void InterpretLDY(System.IO.BinaryWriter OutputFile, bool IsLabelScan)
        {
            EatWhiteSpaces();
            if (sourceProgram[currentIndex] == '#')
            {
                currentIndex++;
                ushort val = ReadWordValue();
                asLength += 3;
                if (!IsLabelScan)
                {
                    OutputFile.Write((byte)0x23);
                    OutputFile.Write(val);
                }

            }
        }

        private void InterpretINCA(System.IO.BinaryWriter OutputFile, bool IsLabelScan) { if (!IsLabelScan) { OutputFile.Write((byte)0x0F); } asLength++; }

        private void InterpretINCB(System.IO.BinaryWriter OutputFile, bool IsLabelScan) { if (!IsLabelScan) { OutputFile.Write((byte)0x10); } asLength++; }

        private void InterpretINCX(System.IO.BinaryWriter OutputFile, bool IsLabelScan) { if (!IsLabelScan) { OutputFile.Write((byte)0x11); } asLength++; }

        private void InterpretINCY(System.IO.BinaryWriter OutputFile, bool IsLabelScan)
        {
            if (!IsLabelScan)
            {

                OutputFile.Write((byte)0x12);
            }
            asLength++;

        }

        private void InterpretINCD(System.IO.BinaryWriter OutputFile, bool IsLabelScan)
        {
            if (!IsLabelScan) { OutputFile.Write((byte)0x13); }
            asLength++;
        }

        private void InterpretDECA(System.IO.BinaryWriter OutputFile, bool IsLabelScan)
        {
            if (!IsLabelScan) { OutputFile.Write((byte)0x14); }
            asLength++;
        }

        private void InterpretDECB(System.IO.BinaryWriter OutputFile, bool IsLabelScan)
        {
            if (!IsLabelScan) { OutputFile.Write((byte)0x15); }
            asLength++;
        }

        private void InterpretDECX(System.IO.BinaryWriter OutputFile, bool IsLabelScan)
        {
            if (!IsLabelScan) { OutputFile.Write((byte)0x16); }
            asLength++;
        }

        private void InterpretDECY(System.IO.BinaryWriter OutputFile, bool IsLabelScan)
        {
            if (!IsLabelScan) { OutputFile.Write((byte)0x17); }
            asLength++;
        }

        private void InterpretDECD(System.IO.BinaryWriter OutputFile, bool IsLabelScan)
        {
            if (!IsLabelScan)
            {
                OutputFile.Write((byte)0x18);
            }
            asLength++;
        }

        private void InterpretADCA(System.IO.BinaryWriter OutputFile, bool IsLabelScan)
        {
            if (!IsLabelScan) { OutputFile.Write((byte)0x1D); }
            asLength++;
        }

        private void InterpretADCB(System.IO.BinaryWriter outputFile, bool IsLabelScan)
        {
            if (!IsLabelScan) { outputFile.Write((byte)0x1E); }
            asLength++;
        }

        private void InterpretADDA(System.IO.BinaryWriter outputFile, bool IsLabelScan)
        {
            EatWhiteSpaces(); if (sourceProgram[currentIndex] == '#')
            {
                currentIndex++; asLength += 2;
                if (IsLabelScan) return;
                ushort val = ReadByteValue();

                if (!IsLabelScan)
                {
                    outputFile.Write((byte)0x1F);
                    outputFile.Write(val);
                }
            }
        }

        private void InterpretADDB(System.IO.BinaryWriter OutputFile, bool IsLabelScan)
        {
            EatWhiteSpaces(); if (sourceProgram[currentIndex] == '#')
            {
                currentIndex++;
                asLength += 2;
                if (IsLabelScan) return;

                ushort val = ReadByteValue();

                if (!IsLabelScan)
                {
                    OutputFile.Write((byte)0x20);
                    OutputFile.Write(val);
                }
            }

        }

        private void InterpretROLB(System.IO.BinaryWriter OutputFile, bool IsLabelScan)
        {
            if (!IsLabelScan) { OutputFile.Write((byte)0x1A); }
            asLength++;
        }

        private void InterpretROLA(System.IO.BinaryWriter OutputFile, bool IsLabelScan)
        {
            if (!IsLabelScan) { OutputFile.Write((byte)0x19); }
            asLength++;
        }

        private void InterpretRORB(System.IO.BinaryWriter OutputFile, bool IsLabelScan)
        {
            if (!IsLabelScan) { OutputFile.Write((byte)0x1C); }
            asLength++;
        }

        private void InterpretRORA(System.IO.BinaryWriter OutputFile, bool IsLabelScan)
        {
            if (!IsLabelScan) { OutputFile.Write((byte)0x1B); }
            asLength++;
        }

        private void InterpretADDAB(System.IO.BinaryWriter OutputFile, bool IsLabelScan)
        {
            if (!IsLabelScan) { OutputFile.Write((byte)0x21); }
            asLength++;
        }
    }
}