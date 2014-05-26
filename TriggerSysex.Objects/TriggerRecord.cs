using System;
using System.Data;
using System.IO;
using System.Text;
using TriggerSysex.Objects.Enums;

namespace TriggerSysex.Objects
{
    /// <summary>
    /// Represents an Alesis Trigger IO SysEx trigger record from data dump
    /// http://www.dmdrummer.com/index.php?topic=824.0
    /// 
    /// 
    /// 
    /*
     * 
 Trigger settings:
    F0 00 00 0E 2C 0D 00 00 0A 02 02 07 07 06 01 0A 02 F7
 header: F0 00 00 0E 2C 0A 02 
 then, in order, each a single byte with exact value:
 trigger number (0-19, 0/1 is a/b for kick, then 2/3 is snare a/b, etc) one byte
 gain
 velocity curve (encoded, 'lin' = 00 and I expect the others are in order)
 threshold
 x-talk
 retrigger
 trigger type (PP = 0 iirc, rest should be in order per the manual too, but haven't verified)
 F7

 18 bytes total.
     * 
     //*/

    // Header*********************10 TR GA VE TH XT RT TT F7 Header*********************10 TR GA VE TH XT RT TT F7 
    // F0 00 00 0E 2C 0D 00 00 0A 02 02 07 07 06 01 0A 02 F7 F0 00 00 0E 2C 0D 00 00 0A 02 03 13 01 05 01 0A 00 F7
    /// </summary>
    [Serializable]
    public class TriggerRecord
    {
        public TriggerRecord()
        {
            Header = TriggerIOConstants.TriggerHeaderConstant;
            Footer = TriggerIOConstants.FooterConstant;
        }

        //public static byte[] HeaderConstant = new byte[7] {0x0F, 0x00, 0x00, 0x0E, 0x2C, 0x0A, 0x01};
        public byte[] Header = new byte[10];

        public byte TriggerNumber;
            // 0-19 0/1 = Kick a/b, 2/3 = Snare a/b... a = (number on back of unit - 1) * 2, b = a + 1
        public byte Gain;
        public byte VelocityCurve;
        public byte Threshold;
        public byte Crosstalk;
        public byte Retrigger;
        public byte TriggerType;
        public byte Footer;
    }
}