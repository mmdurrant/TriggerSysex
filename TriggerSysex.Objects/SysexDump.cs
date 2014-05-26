using System;

namespace TriggerSysex.Objects
{
    [Serializable]
    public class SysexDump
    {
        public TriggerRecord[] TriggerRecords = new TriggerRecord[20];
        public ProgramRecord[] ProgramRecords = new ProgramRecord[21];
    }

    //public struct SysexDump
    //{
    //    public byte[] Records;
    //}

    public class SysexDump2
    {
        public TriggerRecord[] TriggerRecords = new TriggerRecord[20];
        public ProgramRecord[] ProgramRecords = new ProgramRecord[21];
    }
}