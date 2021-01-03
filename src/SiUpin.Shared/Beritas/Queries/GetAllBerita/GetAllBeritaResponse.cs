using System.Collections.Generic;
using SiUpin.Shared.Beritas.Common;

namespace SiUpin.Shared.Beritas.Queries.GetAllBerita
{
    public class GetAllBeritaResponse
    {
        public IList<BeritaDTO> Data { get; set; } = new List<BeritaDTO>();
    }
}
