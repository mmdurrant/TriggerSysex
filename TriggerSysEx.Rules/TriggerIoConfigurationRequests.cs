using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriggerSysex.Objects;
using TriggerSysex.Objects.Interfaces;

namespace TriggerSysEx.Rules
{
    public class TriggerIOConfigurationRequests : ITriggerIOConfigurationRequests
    {
        private ITriggerIODumpReader _dataReader;

        public ITriggerIODumpReader DataReader
        {
            get { return _dataReader ?? (_dataReader = Factories.ReaderFactory.GetDataReader()); }
            set { _dataReader = value; }
        }

        public TriggerIOConfiguration Read(string path)
        {
            var result = DataReader.Read(path);

            return result.AsTriggerIOConfiguration();
        }
    }
}
