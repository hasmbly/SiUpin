using System.Collections.Generic;

namespace SiUpin.Shared.Provinsis.Queries.GetProvinsis
{
    public class GetProvinsisResponse
    {
        public IList<ProvinsiDTO> Data { get; set; }

        public GetProvinsisResponse() => Data = new List<ProvinsiDTO>();
    }
}
