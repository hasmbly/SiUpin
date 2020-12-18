using System.Collections.Generic;
using MediatR;
using SiUpin.Shared.Common;
using SiUpin.Shared.Common.Pagination;
using SiUpin.Shared.Uphs.Common;

namespace SiUpin.Shared.UphGmps.Queries
{
    public class GetUphGmpsRequest : PaginationRequest, IRequest<GetUphGmpsResponse>
    {
        public string FilterByName { get; set; }
    }

    public class GetUphGmpsResponse : GeneralResponse
    {
        public PaginationResponse Pagination { get; set; }

        public IList<UphGmpDTO> Data { get; set; }

        public GetUphGmpsResponse()
        {
            Data = new List<UphGmpDTO>();
        }
    }

    public class UphGmpDTO
    {
        public string UphGmpID { get; set; }
        public string UphID { get; set; }

        public int No { get; set; }
        public string id_gmp { get; set; }
        public string id_uph { get; set; }
        public string nama_gmp { get; set; }
        public string jml_gmp { get; set; }
        public string user { get; set; }

        public UphDTO Uph { get; set; }
    }
}
