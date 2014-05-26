using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TriggerSysex.Objects;
using TriggerSysex.Objects.Enums;
using TriggerSysEx.Rules;

namespace TriggerSysex.Rules_Tests
{
    [TestFixture]
    public class RulesExtenders_Tests
    {
        private TriggerRecord _testRecord;

        [SetUp]
        public void SetUp()
        {
            _testRecord = BuildTestRecord();
        }

        [Test]
        public void AsTriggerSetting_Crosstalk_Test()
        {
            var actual = _testRecord.AsTriggerSetting();
            Assert.AreEqual(_testRecord.Crosstalk, actual.Crosstalk);
        }

        private TriggerRecord BuildTestRecord()
        {
            return new TriggerRecord()
            {
                Crosstalk = 1,
                Footer = TriggerIOConstants.FooterConstant,
                Gain = 12,
                Header = TriggerIOConstants.TriggerHeaderConstant,
                Retrigger = 14,
                Threshold = 0,
                TriggerNumber = (byte) TriggerNumber.KickA,
                TriggerType = (byte) TriggerType.Piezo,
                VelocityCurve = (byte) VelocityCurve.Linear
            };
        }
    }
}
