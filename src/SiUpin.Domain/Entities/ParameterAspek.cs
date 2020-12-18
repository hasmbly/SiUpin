using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiUpin.Domain.Entities
{
    [Table("parameteraspeks")]
    public class ParameterAspek
    {
        public string ParameterAspekID { get; set; }
        public string id_aspek { get; set; }
        public string Name { get; set; }

        public IList<ParameterKriteria> ParameterKriterias { get; set; }

        public ParameterAspek()
        {
            ParameterKriterias = new List<ParameterKriteria>();
        }
    }
}