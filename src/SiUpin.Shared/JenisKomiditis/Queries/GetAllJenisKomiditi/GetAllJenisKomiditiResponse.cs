using System.Collections.Generic;
using SiUpin.Shared.JenisKomiditis.Common.GetAllJenisKomiditi;

namespace SiUpin.Shared.JenisKomiditis.Queries.GetAllJenisKomiditi
{
    public class GetAllJenisKomiditiResponse
    {
        public IList<JenisKomoditiDTO> JenisKomoditis { get; set; }

        public GetAllJenisKomiditiResponse()
        {
            JenisKomoditis = new List<JenisKomoditiDTO>();
        }
    }
}
