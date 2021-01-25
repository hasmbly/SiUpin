using System.Collections.Generic;

namespace SiUpin.Shared.Uphs.Queries.GetCountUphByJenisKomoditi
{
    public class GetCountUphByJenisKomoditiResponse
    {
        public IList<UphByJenisKomoditiDTO> UphByJenisKomoditis { get; set; } = new List<UphByJenisKomoditiDTO>();
    }
}
