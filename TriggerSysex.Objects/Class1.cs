using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriggerSysex.Objects
{
    [Serializable]
    public class TriggerProgramRecord
    {
        public byte NoteNumber;
        public byte MidiChannel;
        public byte ThreeConstant;
    }


    public class TriggerIOConstants
    {
        public const byte FootClickUnknownConstant = 0x03;
        public const byte ProgramUnchangedDefault = 0x7F;
        public const byte FooterConstant = 0x7F;
        public readonly static byte[] ProgramHeaderConstant = new byte[10] { 0x0F, 0x00, 0x00, 0x0E, 0x2C, 0x00, 0x0D, 0x00, 0x46, 0x01 };
        public readonly static byte[] TriggerHeaderConstant = new byte[10] { 0x0F, 0x00, 0x00, 0x0E, 0x2C, 0x0D, 0x00, 0x00, 0x0A, 0x02 };
    }
}
