using System.Collections.Generic;
using MediatR;
using SiUpin.Shared.Common;
using SiUpin.Shared.Common.Pagination;
using SiUpin.Shared.Uphs.Common;

namespace SiUpin.Shared.UphPasars.Queries
{
    public class GetUphPasarsRequest : PaginationRequest, IRequest<GetUphPasarsResponse>
    {
        public string FilterByName { get; set; }
    }

    public class GetUphPasarsResponse : GeneralResponse
    {
        public PaginationResponse Pagination { get; set; }

        public IList<UphPasarDTO> Data { get; set; }

        public GetUphPasarsResponse()
        {
            Data = new List<UphPasarDTO>();
        }
    }

    public class UphPasarDTO
    {
        public string UphPasarID { get; set; }
        public string UphID { get; set; }

        public int No { get; set; }
        public string id_pasar { get; set; }
        public string id_uph { get; set; }
        public string nama_uph { get; set; }
        public string mekanisme { get; set; }
        public string nilai_mekanisme { get; set; }
        public string jangkauan { get; set; }
        public string jml_penjualan { get; set; }
        public string omset { get; set; }
        public string lain { get; set; }
        public string user { get; set; }

        public UphDTO Uph { get; set; }
    }
}
