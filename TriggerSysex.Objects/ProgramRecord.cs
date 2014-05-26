using System;

namespace TriggerSysex.Objects
{
    /// <summary>
    /// Represents an Alesis Trigger IO SysEx kit record from data dump
    /// http://www.dmdrummer.com/index.php?topic=824.0
    /// </summary>
    ///
    [Serializable]
    public class ProgramRecord
    {
        /*
         * 
        header: F0 00 00 0E 2C 0D 00 00 46 01
        then the program number, so for kit 0, put 00 (one byte)
        then there are 20 trigger settings. They appear to be in order, they will be kick trigger A, then kick triggerB, then snare triggerA, etc.
        each one is:
        note number (one byte)
        midi channel
         * 0x3 (always 0x3 - not sure what this is yet)
        3 bytes per trigger.
        Then 2 bytes for foot chik setting: note number, then the 0x3
        Open HH setting: note number, then midi channel
        One byte with either 7F to not change the program, or a program number
        F7 for the footer
         * 
         */

        public ProgramRecord()
        {
            Header = TriggerIOConstants.ProgramHeaderConstant;
            Footer = TriggerIOConstants.FooterConstant;
            UnknownMagicNumber = TriggerIOConstants.FootClickUnknownConstant;

        }

        /// <summary>
        /// Header - should be 10 bytes
        /// Should be set to HeaderConstant
        /// </summary>
        public byte[] Header = new byte[10];

        /// <summary>
        /// Kit/Program Number - 1 byte
        /// </summary>
        public byte ProgramNumber; // Program Number
        
        /// <summary>
        /// There should be 2 TriggerProgramRecords - 3 bytes a piece = 60 bytes
        /// </summary>
        public TriggerProgramRecord[] TriggerProgramRecords = new TriggerProgramRecord[30];
        
        // Foot click setting - 2 bytes, note number followed by 0x3 the magic number
        public byte FootClick;
        public byte UnknownMagicNumber;
        // Open hihat midi note and channel
        public byte OpenHiHatNote;
        public byte OpenHiHatMidiChannel;
        
        // Program change byte - 7F to not change or the program number. ProgramDefaultConstant = 0x7F
        public byte ProgramChange;
        // F7
        public byte Footer = TriggerIOConstants.FooterConstant;
    }
}