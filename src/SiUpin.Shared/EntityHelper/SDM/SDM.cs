using System.Collections.Generic;

namespace SiUpin.Shared.EntityHelper.SDM
{
    public class SDM
    {
        public IDictionary<string, string> SDMStrukturPermodalan { get; set; }
        public IDictionary<string, string> SDMSumberModal { get; set; }

        public SDM()
        {
            SDMStrukturPermodalan = new Dictionary<string, string>()
            {
                {"1", "Modal Sendiri"},
                {"2", "Sebagian dari pihak lain"},
                {"3", "Sepenuhnya dari pihak lain"}
            };

            SDMSumberModal = new Dictionary<string, string>()
            {
                {"1", "Bank"},
                {"2", "Koperasi"},
                {"3", "Non Bank"},
                {"4", "Perorangan"},
                {"5", "Keluarga"},
                {"6", "Lainya"}
            };
        }
    }
}