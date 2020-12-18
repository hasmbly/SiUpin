using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiUpin.Domain.Entities
{
    [Table("parameterkriterias")]
    public class ParameterKriteria
    {
        public string ParameterKriteriaID { get; set; }
        public string id_kriteria { get; set; }
        public string ParameterAspekID { get; set; }

        public string Name { get; set; }

        public ParameterAspek ParameterAspek { get; set; }
        public IList<ParameterIndikator> ParameterIndikators { get; set; }

        public ParameterKriteria()
        {
            ParameterIndikators = new List<ParameterIndikator>();
        }
    }
}
