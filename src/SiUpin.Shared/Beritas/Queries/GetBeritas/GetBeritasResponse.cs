using System.Collections.Generic;
using SiUpin.Shared.Common.Pagination;

namespace SiUpin.Shared.Beritas.Queries.GetBeritas
{
    public class GetBeritasResponse
    {
        public PaginationResponse Pagination { get; set; }

        public IList<BeritaDTO> Data { get; set; }

        public GetBeritasResponse()
        {
            Data = new List<BeritaDTO>();
        }
    }
}
