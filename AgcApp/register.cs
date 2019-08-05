// octal numbers == '0012'
// hex numbers == '0xff'

namespace AgcApp
{
    public interface IMemoryRegister
    {
        void Load(dynamic value);
    }
    public class ByteMemoryRegister:IMemoryRegister
    {
        public byte Register{get;protected set;}
        public void Load(dynamic value)
        {
            Register = value;
        }
    }
    public class WordMemoryRegister:IMemoryRegister
    {
        public short Register{get;protected set;}
        public void Load(dynamic value)
        {
            Register = value;
        }
    }
}