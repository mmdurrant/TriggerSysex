using System;
using System.Data.Odbc;
using System.Linq;
using TriggerSysex.Objects;
using TriggerSysex.Objects.Enums;

namespace TriggerSysEx.Rules
{
    public static class RulesExtenders
    {
        public static TriggerIOConfiguration AsTriggerIOConfiguration(this SysexDump input)
        {
            return new TriggerIOConfiguration()
            {
                ProgramSettings = input.ProgramRecords.Select(x => x.AsProgramSetting()),
                TriggerSettings = input.TriggerRecords.Select(x => x.AsTriggerSetting())
            };
        }

        public static ProgramSetting AsProgramSetting(this ProgramRecord input)
        {
            var result = default(ProgramSetting);

            if (input != null)
            {
                result = new ProgramSetting
                {
                    FootClickNote = (MidiNote) input.FootClick,
                    ProgramNumber = input.ProgramNumber,
                    ProgramChangeNumber = input.ProgramNumber,
                    OpenHiHatNote = (MidiNote) input.OpenHiHatNote,
                    OpenHiHatChannel = (MidiChannel) input.OpenHiHatMidiChannel,
                    TriggerSettings = input.TriggerProgramRecords.Select(x => x.AsProgramTriggerAssignment())
                };
            }

            return result;
        }

        public static TriggerSetting AsTriggerSetting(this TriggerRecord input)
        {
            var result = default(TriggerSetting);

            if (input != null)
            {
                result = new TriggerSetting
                {
                    Crosstalk = input.Crosstalk,
                    Gain = input.Gain,
                    Retrigger = input.Retrigger,
                    Threshold = input.Threshold,
                    TriggerNumber = (TriggerNumber) input.TriggerNumber,
                    TriggerType = (TriggerType) input.TriggerType,
                    VelocityCurve = (VelocityCurve) input.VelocityCurve
                };
            }

            return result;
        }

        public static ProgramTriggerAssignment AsProgramTriggerAssignment(this TriggerProgramRecord input)
        {
            var result = default(ProgramTriggerAssignment);

            if (input != null)
            {
                result = new ProgramTriggerAssignment
                {
                    MidiChannel = (MidiChannel) input.MidiChannel,
                    MidiNote = (MidiNote) input.NoteNumber
                };
            }

            return result;
        }
    }
}