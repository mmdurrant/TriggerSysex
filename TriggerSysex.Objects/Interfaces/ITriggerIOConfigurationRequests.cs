namespace TriggerSysex.Objects.Interfaces
{
    public interface ITriggerIOConfigurationRequests : ISysExConfigurationRequests
    {
        TriggerIOConfiguration Read(string path);
    }
}