using System.Collections.Generic;

namespace SiUpin.Domain.Entities
{
    public class ParameterJawaban
    {
        public string ParameterJawabanID { get; set; }
        public string ParameterIndikatorID { get; set; }

        public string Name { get; set; }
        public string Skor { get; set; }

        public ParameterIndikator ParameterIndikator { get; set; }
        public IList<UphParameter> UphParameters { get; set; }

        public ParameterJawaban()
        {
            UphParameters = new List<UphParameter>();
        }
    }
}