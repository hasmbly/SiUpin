using System.Collections.Generic;

namespace SiUpin.Shared.Kelurahans.Queries.GetKelurahansByKecamatanID
{
    public class GetKelurahansByKecamatanIDResponse
    {
        public IList<KelurahanDTO> Data { get; set; }

        public GetKelurahansByKecamatanIDResponse() => Data = new List<KelurahanDTO>();
    }
}
