using System.Collections.Generic;
using TriggerSysex.Objects.Enums;

namespace TriggerSysex.Objects
{
    public class ProgramSetting
    {
        public int ProgramNumber { get; set; }
        public IEnumerable<ProgramTriggerAssignment> TriggerSettings { get; set; }
        public bool HasProgramChange { get { return ProgramChangeNumber == TriggerIOConstants.ProgramUnchangedDefault; }}
        public int ProgramChangeNumber { get; set; }
        public MidiNote FootClickNote { get; set; }
        public MidiNote OpenHiHatNote { get; set; }
        public MidiChannel OpenHiHatChannel { get; set; }
        
    }
}