using System.Collections;
using System.Collections.Generic;

namespace TriggerSysex.Objects
{
    public class TriggerIOConfiguration
    {
        public IEnumerable<TriggerSetting> TriggerSettings { get; set; }
        public IEnumerable<ProgramSetting> ProgramSettings { get; set; }
    }
}