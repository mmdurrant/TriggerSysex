namespace TriggerSysex.Objects.Interfaces
{
    public interface ISysexDumpReader
    {
        SysexDump Read(string path);
        int Write(SysexDump dump, string path);
        SysexDump Read(byte[] bytes);
    }
}