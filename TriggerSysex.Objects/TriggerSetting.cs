using System.Collections;
using TriggerSysex.Objects.Enums;

namespace TriggerSysex.Objects
{
    public class TriggerSetting
    {
        public TriggerNumber TriggerNumber { get; set; }
        public int Gain { get; set; }
        public VelocityCurve VelocityCurve { get; set; }
        public int Threshold { get; set; }
        public int Crosstalk { get; set; }
        public int Retrigger { get; set; }
        public TriggerType TriggerType { get; set; }
    }

    public class ProgramTriggerAssignment
    {
        public MidiNote MidiNote { get; set; }
        public MidiChannel MidiChannel { get; set; }
    }

    public enum MidiChannel
    {
        Ch1 = 1,
        Ch2 = 2,
        Ch3 = 3,
        Ch4 = 4,
        Ch5 = 5,
        Ch6 = 6,
        Ch7 = 7,
        Ch8 = 8,
        Ch9 = 9,
        Ch10 = 10,
        Ch11 = 11,
        Ch12 = 12,
        Ch13 = 13,
        Ch14 = 14,
        Ch15 = 15,
        Ch16 = 16,
        ChAll = 0,
        ChNone = -1
    }
}