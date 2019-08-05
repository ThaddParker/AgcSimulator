using System;
using System.Collections;
using System.IO;

namespace AgcApp
{
    public class Machine
    {
        private byte[] B32Memory;
        private ushort _startAddress;
        private ushort _executionAddress;
        private ushort _instructionPointer;
        private byte _registerA;
        private byte _registerB;
        private ushort _registerX;
        private ushort _registerY;
        private ushort _registerD;
        private byte _compareFlag;
        private byte _processorFlags;
        private Hashtable _constants;
        private Hashtable _globalValues;


        public Machine()
        {
            B32Memory = new byte[65535];
            _startAddress = 0;
            _executionAddress = 0;
            _registerA = 0;
            _registerB = 0;
            _registerD = 0;
            _registerX = 0;
            _registerY = 0;
            _compareFlag = 0;
            _processorFlags = 0;
            _constants = new Hashtable();
            _globalValues = new Hashtable();

            UpdateRegisterStatus();
        }
        private string UpdateRegisterStatus()
        {
            string strRegisters = "";

            strRegisters = "Register A = $" + _registerA.ToString("X").PadLeft(2, '0');
            strRegisters += "     Register B = $" + _registerB.ToString("X").PadLeft(2, '0');
            strRegisters += "     Register D = $" + _registerD.ToString("X").PadLeft(4, '0');
            strRegisters += "\nRegister X = $" + _registerX.ToString("X").PadLeft(4, '0');
            strRegisters += "   Register Y = $" + _registerY.ToString("X").PadLeft(4, '0');
            strRegisters += "\nCompare Flag = $" + _compareFlag.ToString("X").PadLeft(2, '0');
            strRegisters += "   Instruction Pointer = $" + _instructionPointer.ToString("X").PadLeft(4, '0');

            //this.lblRegisters.Text = strRegisters;
            return strRegisters;
        }


        public override string ToString()
        {
            return UpdateRegisterStatus();
        }

        public void LoadProgramFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException();

            System.IO.BinaryReader br;
            System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open);

            br = new System.IO.BinaryReader(fs);

            var Magic1 = br.ReadByte();
            var Magic2 = br.ReadByte();
            var Magic3 = br.ReadByte();

            if (Magic1 != 'B' && Magic2 != '3' && Magic3 != '2')
            {
                throw new ArgumentException("This is not a valid B32 file!");
            }

            _startAddress = br.ReadUInt16();
            _executionAddress = br.ReadUInt16();
            ushort Counter = 0;
            while ((br.PeekChar() != -1))
            {
                B32Memory[(_startAddress + Counter)] = br.ReadByte();
                Counter++;
            }

            br.Close();
            fs.Close();

            _instructionPointer = _executionAddress;

            ExecuteProgram(_startAddress, Counter);
        }

        private void ExecuteProgram(ushort executionStartAddress, ushort programLength)
        {
            //ProgLength = 64000;
            while (programLength > 0)
            {

                byte instruction = B32Memory[_instructionPointer];
                programLength--;

                switch (instruction)
                {
                    
                    case 0x02: // LDX - load value into X register
                        _registerX = (ushort)((B32Memory[(_instructionPointer + 2)]) << 8);
                        _registerX += B32Memory[(_instructionPointer + 1)];
                        programLength -= 2;
                        _instructionPointer += 3;

                        UpdateRegisterStatus();
                        break;
                    case 0x23: // LDY #<value>
                        _registerY = (ushort)((B32Memory[(_instructionPointer + 2)]) << 8);
                        _registerY += B32Memory[(_instructionPointer + 1)];
                        programLength -= 2;
                        _instructionPointer += 3;

                        UpdateRegisterStatus();
                        break;
                }
                
               

                if (instruction == 0x01) // LDA #<value>
                {
                    _registerA = B32Memory[(_instructionPointer + 1)];
                    SetRegisterD();
                    programLength -= 1;
                    _instructionPointer += 2;

                    UpdateRegisterStatus();

                    continue;

                }
                if (instruction == 0x22) // LDB #<value>
                {
                    _registerB = B32Memory[(_instructionPointer + 1)];
                    SetRegisterD();
                    programLength -= 1;
                    _instructionPointer += 2;

                    UpdateRegisterStatus();

                    continue;
                }
                if (instruction == 0x03) // STA ,X
                {
                    B32Memory[_registerX] = _registerA;
                    // b32Screen1.Poke(Register_X, Register_A);
                    _instructionPointer++;

                    UpdateRegisterStatus();

                    continue;
                }

                if (instruction == 0x04) // END
                {
                    _instructionPointer++;
                    UpdateRegisterStatus();
                    break;
                }
                if (instruction == 0x05) // CMPA
                {
                    byte compValue = B32Memory[_instructionPointer + 1];

                    _compareFlag = 0;

                    if (_registerA == compValue)
                        _compareFlag = (byte)(_compareFlag | 1);
                    if (_registerA != compValue)
                        _compareFlag = (byte)(_compareFlag | 2);
                    if (_registerA < compValue)
                        _compareFlag = (byte)(_compareFlag | 4);
                    if (_registerA > compValue)
                        _compareFlag = (byte)(_compareFlag | 8);

                    _instructionPointer += 2;

                    UpdateRegisterStatus();

                    continue;
                }
                if (instruction == 0x06) // CMPB
                {
                    byte CompValue = B32Memory[_instructionPointer + 1];

                    _compareFlag = 0;

                    if (_registerB == CompValue)
                        _compareFlag = (byte)(_compareFlag | 1);
                    if (_registerB != CompValue)
                        _compareFlag = (byte)(_compareFlag | 2);
                    if (_registerB < CompValue)
                        _compareFlag = (byte)(_compareFlag | 4);
                    if (_registerB > CompValue)
                        _compareFlag = (byte)(_compareFlag | 8);

                    _instructionPointer += 2;

                    UpdateRegisterStatus();

                    continue;
                }
                if (instruction == 0x07) // CMPX
                {
                    ushort CompValue = (ushort)((B32Memory[(_instructionPointer + 2)]) << 8); CompValue += B32Memory[(_instructionPointer + 1)];

                    _compareFlag = 0;

                    if (_registerX == CompValue)
                        _compareFlag = (byte)(_compareFlag | 1);
                    if (_registerX != CompValue)
                        _compareFlag = (byte)(_compareFlag | 2);
                    if (_registerX < CompValue)
                        _compareFlag = (byte)(_compareFlag | 4);
                    if (_registerX > CompValue)
                        _compareFlag = (byte)(_compareFlag | 8);

                    _instructionPointer += 3;

                    UpdateRegisterStatus();

                    continue;
                }
                if (instruction == 0x08) //CMPY
                {
                    ushort compValue = (ushort)((B32Memory[(_instructionPointer + 2)]) << 8); compValue += B32Memory[(_instructionPointer + 1)];

                    _compareFlag = 0;

                    if (_registerY == compValue)
                        _compareFlag = (byte)(_compareFlag | 1);
                    if (_registerY != compValue)
                        _compareFlag = (byte)(_compareFlag | 2);
                    if (_registerY < compValue)
                        _compareFlag = (byte)(_compareFlag | 4);
                    if (_registerY > compValue)
                        _compareFlag = (byte)(_compareFlag | 8);

                    _instructionPointer += 3;

                    UpdateRegisterStatus();

                    continue;
                }
                if (instruction == 0x09) //CMPD
                {
                    ushort CompValue = (ushort)((B32Memory[(_instructionPointer + 2)]) << 8);
                    CompValue += B32Memory[(_instructionPointer + 1)];

                    _compareFlag = 0;


                    if (_registerD == CompValue)
                        _compareFlag = (byte)(_compareFlag | 1);
                    if (_registerD != CompValue)
                        _compareFlag = (byte)(_compareFlag | 2);
                    if (_registerD < CompValue)
                        _compareFlag = (byte)(_compareFlag | 4);
                    if (_registerD > CompValue)
                        _compareFlag = (byte)(_compareFlag | 8);

                    _instructionPointer += 3;

                    UpdateRegisterStatus();

                    continue;
                }
                if (instruction == 0x0A) // JMP
                {
                    ushort JmpValue = (ushort)((B32Memory[(_instructionPointer + 2)]) << 8);
                    JmpValue += B32Memory[(_instructionPointer + 1)];

                    _instructionPointer = JmpValue;

                    UpdateRegisterStatus();

                    continue;

                }
                if (instruction == 0x0B) // JEQ
                {
                    ushort JmpValue = (ushort)((B32Memory[(_instructionPointer + 2)]) << 8);
                    JmpValue += B32Memory[(_instructionPointer + 1)];

                    if ((_compareFlag & 1) == 1)
                    {
                        _instructionPointer = JmpValue;
                    }
                    else
                    {
                        _instructionPointer += 3;
                    }
                    UpdateRegisterStatus();

                    continue;
                }
                if (instruction == 0x0C) // JNE
                {
                    ushort JmpValue = (ushort)((B32Memory[(_instructionPointer + 2)]) << 8);
                    JmpValue += B32Memory[(_instructionPointer + 1)];


                    if ((_compareFlag & 2) == 2)
                    {
                        _instructionPointer = JmpValue;
                    }
                    else
                    {
                        _instructionPointer += 3;
                    }
                    UpdateRegisterStatus();

                    continue;
                }
                if (instruction == 0x0D) // JGT
                {
                    ushort JmpValue = (ushort)((B32Memory[(_instructionPointer + 2)]) << 8);
                    JmpValue += B32Memory[(_instructionPointer + 1)];

                    if ((_compareFlag & 4) == 4)
                    {
                        _instructionPointer = JmpValue;
                    }
                    else
                    {
                        _instructionPointer += 3;
                    }
                    UpdateRegisterStatus();


                    continue;
                }
                if (instruction == 0x0E) // JLT
                {
                    ushort JmpValue = (ushort)((B32Memory[(_instructionPointer + 2)]) << 8);
                    JmpValue += B32Memory[(_instructionPointer + 1)];

                    if ((_compareFlag & 8) == 8)
                    {
                        _instructionPointer = JmpValue;
                    }
                    else
                    {
                        _instructionPointer += 3;
                    }
                    UpdateRegisterStatus();

                    continue;
                }
                if (instruction == 0x0F) // INCA
                {
                    if (_registerA == 0xFF)
                    {
                        _processorFlags = (byte)(_processorFlags | 1);
                    }
                    else
                    {
                        _processorFlags = (byte)(_processorFlags & 0xFE);
                    }

                    unchecked { _registerA++; }
                    SetRegisterD();
                    _instructionPointer++;
                    UpdateRegisterStatus(); continue;

                }

                if (instruction == 0x10) // INCB
                {
                    if (_registerB == 0xFF)
                    {
                        _processorFlags = (byte)(_processorFlags | 1);
                    }
                    else
                    {
                        _processorFlags = (byte)(_processorFlags & 0xFE);
                    }

                    unchecked { _registerB++; }
                    SetRegisterD(); _instructionPointer++; UpdateRegisterStatus(); continue;

                }

                if (instruction == 0x11) // INCX
                {
                    if (_registerX == 0xFFFF) { _processorFlags = (byte)(_processorFlags | 1); } else { _processorFlags = (byte)(_processorFlags & 0xFE); }

                    unchecked { _registerX++; }
                    _instructionPointer++; UpdateRegisterStatus(); continue;
                }

                if (instruction == 0x12) // INCY
                {
                    if (_registerY == 0xFFFF) { _processorFlags = (byte)(_processorFlags | 1); } else { _processorFlags = (byte)(_processorFlags & 0xFE); }

                    unchecked { _registerY++; }
                    _instructionPointer++; UpdateRegisterStatus(); continue;
                }

                if (instruction == 0x13) // INCD

                {
                    if (_registerD == 0xFFFF) { _processorFlags = (byte)(_processorFlags | 1); } else { _processorFlags = (byte)(_processorFlags & 0xFE); }

                    unchecked { _registerD++; _registerA = (byte)(_registerD >> 8); _registerB = (byte)(_registerD & 255); }

                    _instructionPointer++; UpdateRegisterStatus(); continue;
                }

                if (instruction == 0x14) // DECA
                {
                    _processorFlags = (byte)(_processorFlags & 0xFE);

                    unchecked { _registerA--; }
                    SetRegisterD(); _instructionPointer++; UpdateRegisterStatus(); continue;
                }

                if (instruction == 0x15) // DECB
                {
                    _processorFlags = (byte)(_processorFlags & 0xFE);

                    unchecked { _registerB--; }
                    SetRegisterD(); _instructionPointer++; UpdateRegisterStatus(); continue;
                }

                if (instruction == 0x16) // DECX
                {
                    _processorFlags = (byte)(_processorFlags & 0xFE);

                    unchecked { _registerX--; }
                    _instructionPointer++; UpdateRegisterStatus(); continue;
                }

                if (instruction == 0x17) // DECY
                {
                    _processorFlags = (byte)(_processorFlags & 0xFE);


                    unchecked { _registerY--; }
                    _instructionPointer++; UpdateRegisterStatus(); continue;
                }

                if (instruction == 0x18) // DECD
                {
                    _processorFlags = (byte)(_processorFlags & 0xFD);

                    unchecked { _registerD--; _registerA = (byte)(_registerD >> 8); _registerB = (byte)(_registerD & 255); }

                    _instructionPointer++; UpdateRegisterStatus(); continue;
                }

                if (instruction == 0x19) // ROLA
                {
                    byte OldCarryFlag = (byte)(_processorFlags & 2);

                    if ((_registerA & 128) == 128)
                    {
                        _processorFlags = (byte)(_processorFlags | 2);
                    }
                    else
                    {
                        _processorFlags = (byte)(_processorFlags & 0xFD);
                    }
                    _registerA = (byte)(_registerA << 1);

                    if (OldCarryFlag > 0) { _registerA = (byte)(_registerA | 1); }

                    SetRegisterD(); _instructionPointer++; UpdateRegisterStatus(); continue;
                }

                if (instruction == 0x1A) // ROLB
                {
                    byte OldCarryFlag = (byte)(_processorFlags & 2);


                    if ((_registerB & 128) == 128) { _processorFlags = (byte)(_processorFlags | 2); } else { _processorFlags = (byte)(_processorFlags & 0xFD); }
                    _registerB = (byte)(_registerB << 1);

                    if (OldCarryFlag > 0) { _registerB = (byte)(_registerB | 1); }

                    SetRegisterD(); _instructionPointer++; UpdateRegisterStatus(); continue;
                }

                if (instruction == 0x1B) // RORA
                {
                    byte OldCarryFlag = (byte)(_processorFlags & 2);

                    if ((_registerA & 1) == 1) { _processorFlags = (byte)(_processorFlags | 2); } else { _processorFlags = (byte)(_processorFlags & 0xFD); }
                    _registerA = (byte)(_registerA >> 1);

                    if (OldCarryFlag > 0) { _registerA = (byte)(_registerA | 128); }

                    SetRegisterD(); _instructionPointer++; UpdateRegisterStatus(); continue;
                }

                if (instruction == 0x1C) // RORB
                {
                    byte OldCarryFlag = (byte)(_processorFlags & 2);

                    if ((_registerB & 1) == 1) { _processorFlags = (byte)(_processorFlags | 2); }
                    else
                    {
                        _processorFlags = (byte)(_processorFlags & 0xFD);

                    }
                    _registerB = (byte)(_registerB >> 1);

                    if (OldCarryFlag > 0) { _registerB = (byte)(_registerB | 128); }

                    SetRegisterD(); _instructionPointer++; UpdateRegisterStatus();
                    continue;
                }
                if (instruction == 0x1D) // ADCA
                {
                    if ((byte)(_processorFlags & 2) == 2)
                    {
                        if (_registerA == 0xFF)
                        {
                            _processorFlags = (byte)(_processorFlags | 1);
                        }
                        else
                        {
                            _processorFlags = (byte)(_processorFlags & 0xFE);
                        }

                        unchecked { _registerA++; }
                        SetRegisterD();
                    }
                    _instructionPointer++;
                    UpdateRegisterStatus(); continue;
                }

                if (instruction == 0x1E) // ADCB
                {
                    if ((byte)(_processorFlags & 2) == 2)
                    {
                        if (_registerB == 0xFF) { _processorFlags = (byte)(_processorFlags | 1); } else { _processorFlags = (byte)(_processorFlags & 0xFE); }

                        unchecked { _registerB++; }
                        SetRegisterD();
                    }
                    _instructionPointer++;
                    UpdateRegisterStatus();
                    continue;
                }

                if (instruction == 0x1F) // ADDA
                {
                    byte val = B32Memory[(_instructionPointer + 1)];

                    if (_registerA == 0xFF && val > 0) { _processorFlags = (byte)(_processorFlags | 1); } else { _processorFlags = (byte)(_processorFlags & 0xFE); }

                    unchecked { _registerA += val; }
                    SetRegisterD();

                    _instructionPointer += 2; UpdateRegisterStatus(); continue;
                }

                if (instruction == 0x20) // ADDB
                {
                    byte val = B32Memory[(_instructionPointer + 1)];

                    if (_registerB == 0xFF && val > 0) { _processorFlags = (byte)(_processorFlags | 1); } else { _processorFlags = (byte)(_processorFlags & 0xFE); }

                    unchecked { _registerB += val; }
                    SetRegisterD();

                    _instructionPointer += 2; UpdateRegisterStatus(); continue;
                }

                if (instruction == 0x21) // ADDAB
                {
                    if ((255 - _registerA) > (_registerB)) { _processorFlags = (byte)(_processorFlags | 1); }
                    else
                    { _processorFlags = (byte)(_processorFlags & 0xFE); }

                    unchecked { _registerD = (ushort)(((ushort)_registerB) + ((ushort)_registerA)); }

                    _registerA = (byte)(_registerD >> 8); _registerB = (byte)(_registerD & 255);

                    _instructionPointer++; UpdateRegisterStatus(); continue;
                }
            }
        }

        private void SetRegisterD()
        {
            _registerD = (ushort)(_registerA << 8 + _registerB);
        }

        public void Reset()
        {
            // reset all items
        }
    }
}
