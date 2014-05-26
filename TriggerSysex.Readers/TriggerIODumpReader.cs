using System;
using System.Diagnostics;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using TriggerSysex.Objects;
using TriggerSysex.Objects.Enums;
using TriggerSysex.Objects.Interfaces;

namespace TriggerSysex.Readers
{
    public class TriggerIODumpReader : ITriggerIODumpReader
    {
        private IFileSystem _fileSystem;

        public IFileSystem FileSystem
        {
            get { return _fileSystem ?? (_fileSystem = new FileSystem()); }
            set { _fileSystem = value; }
        }

        

        public SysexDump Read(byte[] bytes)
        {
            var result = new SysexDump();
            using (var stream = new MemoryStream(bytes))
            {
                result = ReadFromStream(stream);
            }

            return result;
        }

        private SysexDump ReadFromStream(Stream stream)
        {
            var result = new SysexDump();
            var programRecords = GetProgramRecordsFromStream(stream);
            result.ProgramRecords = programRecords.ToArray();
            result.TriggerRecords = GetTriggerRecordsFromStream(stream);
            
            

            return result;
        }

        private TriggerRecord[] GetTriggerRecordsFromStream(Stream stream)
        {
            var result = new TriggerRecord[20];

            /*
             *    * 

    /// </summary>
    [Serializable]
    public class TriggerRecord
    {
        //public static byte[] HeaderConstant = new byte[7] {0x0F, 0x00, 0x00, 0x0E, 0x2C, 0x0A, 0x01};
        public byte[] Header = new byte[7];

        public TriggerNumber TriggerNumber;
            // 0-19 0/1 = Kick a/b, 2/3 = Snare a/b... a = (number on back of unit - 1) * 2, b = a + 1
        public byte Gain;
        public byte VelocityCurve;
        public byte Threshold;
        public byte Crosstalk;
        public byte Retrigger;
        public byte TriggerType;
        public byte Footer;
    }

             * 
             */
            
            for (var i = 0; i < 20; i++)
            {
                stream.Position += TriggerIOConstants.TriggerHeaderConstant.Length;
                result[i] = new TriggerRecord();
                result[i].TriggerNumber = (byte) stream.ReadByte();
                result[i].Gain = (byte) stream.ReadByte();
                result[i].VelocityCurve = (byte)stream.ReadByte();
                result[i].Threshold = (byte) stream.ReadByte();
                result[i].Crosstalk = (byte) stream.ReadByte();
                result[i].Retrigger = (byte) stream.ReadByte();
                result[i].TriggerType = (byte) stream.ReadByte();
                // footer
                stream.Position += 1;
            }


            return result;
        }

        private ProgramRecord[] GetProgramRecordsFromStream(Stream stream)
        {
            var programRecords = new ProgramRecord[21];
            

            stream.Position += TriggerIOConstants.ProgramHeaderConstant.Length;

            var programRecord = new ProgramRecord();
            programRecord.TriggerProgramRecords = new TriggerProgramRecord[20];

            programRecord.ProgramNumber = (byte)stream.ReadByte();

            for (var i = 0; i < 21; i++)
            {
                if (i < 20)
                {
                    programRecord.TriggerProgramRecords[i] = new TriggerProgramRecord();
                    programRecord.TriggerProgramRecords[i].MidiChannel = (byte)stream.ReadByte();
                    programRecord.TriggerProgramRecords[i].NoteNumber = (byte)stream.ReadByte();
                    programRecord.TriggerProgramRecords[i].ThreeConstant = (byte)stream.ReadByte(); // should always be three.
                }
                else if (i == 20)
                {
                    programRecord.OpenHiHatMidiChannel = (byte)stream.ReadByte();
                    programRecord.OpenHiHatNote = (byte)stream.ReadByte();
                    programRecord.UnknownMagicNumber = (byte)stream.ReadByte();
                    // footer;
                    stream.Position += 1; // F7
                    
                }
                programRecords[i] = programRecord;
            }
            
            
            return programRecords;
        }

        public SysexDump Read(string path)
        {
            var result = new SysexDump();
            if (!FileSystem.File.Exists(path)) throw new ArgumentException(path + " is not a valid path.", "path");
            
            using (var file = FileSystem.File.OpenRead(FileSystem.Path.GetFullPath(path)))
            {
                result = ReadFromStream(file);
            }

            return result;
        }

        public int Write(SysexDump dump, string path)
        {

            throw new NotImplementedException();
            return 0;
        }
    }
}