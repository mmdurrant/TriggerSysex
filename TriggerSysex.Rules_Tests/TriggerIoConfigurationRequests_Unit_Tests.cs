using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TriggerSysex.Objects;
using TriggerSysex.Objects.Interfaces;
using TriggerSysEx.Rules;

namespace TriggerSysex.Rules_Tests
{
    [TestFixture]
    public class TriggerIOConfigurationRequests_Unit_Tests
    {
        private TriggerIOConfigurationRequests _target;
        private Mock<ITriggerIODumpReader> _mockReader;
        private SysexDump _testValue;

        [SetUp]
        public void SetUp()
        {
            _target = new TriggerIOConfigurationRequests();
            _mockReader = new Mock<ITriggerIODumpReader>(MockBehavior.Strict);
            _target.DataReader = _mockReader.Object;
            SetupDefaultMockBehaviors();
        }

        private void SetupDefaultMockBehaviors()
        {
            _testValue = new SysexDump();
            _mockReader.Setup(x => x.Read(It.IsAny<byte[]>())).Returns(_testValue);
            _mockReader.Setup(x => x.Read(It.IsAny<string>())).Returns(_testValue);
        }

        [Test]
        public void Read_ReturnsResults_Test()
        {
            var actual = _target.Read(@".\data.sysex");
            Assert.NotNull(actual);
        }
    }
}
