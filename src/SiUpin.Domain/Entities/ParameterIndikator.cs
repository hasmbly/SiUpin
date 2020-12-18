using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiUpin.Domain.Entities
{
    [Table("parameterindikators")]
    public class ParameterIndikator
    {
        public string ParameterIndikatorID { get; set; }
        public string id_indikator { get; set; }
        public string ParameterKriteriaID { get; set; }

        public string Name { get; set; }

        public ParameterKriteria ParameterKriteria { get; set; }
        public IList<ParameterJawaban> ParameterJawabans { get; set; }

        public ParameterIndikator()
        {
            ParameterJawabans = new List<ParameterJawaban>();
        }
    }
}