using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriggerSysex.Objects;
using TriggerSysex.Objects.Interfaces;
using TriggerSysex.Readers;

namespace TriggerSysEx.Rules.Factories
{
    public static class ReaderFactory
    {
        public static ITriggerIODumpReader GetDataReader()
        {
            return new TriggerIODumpReader();
        }
    }
}
