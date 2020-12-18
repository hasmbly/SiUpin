using System.Collections.Generic;
using SiUpin.Shared.ParameterJawabans.Common;

namespace SiUpin.Shared.ParameterJawabans.Queries.GetParameterJawabansByIndikatorName
{
    public class GetParameterJawabansByIndikatorNameResponse
    {
        public IList<ParameterJawabanDTO> ParameterJawabans { get; set; } = new List<ParameterJawabanDTO>();
    }
}
