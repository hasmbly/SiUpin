using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiUpin.Domain.Entities
{
    [Table("parameterjawabans")]
    public class ParameterJawaban
    {
        public string ParameterJawabanID { get; set; }
        public string ParameterIndikatorID { get; set; }

        public string Name { get; set; }
        public string Skor { get; set; }

        public ParameterIndikator ParameterIndikator { get; set; }

        public IList<Uph> UphParameterBadanHukums { get; set; }
        public IList<Uph> UphParameterAdministrasis { get; set; }
        public IList<Uph> UphParameterBentukLembagas { get; set; }
        public IList<Uph> UphParameterStatusUphs { get; set; }

        //public IList<UphParameter> UphParameters { get; set; }

        public ParameterJawaban()
        {
            UphParameterBadanHukums = new List<Uph>();
            UphParameterAdministrasis = new List<Uph>();
            UphParameterBentukLembagas = new List<Uph>();
            UphParameterStatusUphs = new List<Uph>();
        }
    }
}