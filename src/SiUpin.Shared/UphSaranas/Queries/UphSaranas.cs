using System.Collections.Generic;
using MediatR;
using SiUpin.Shared.Common;
using SiUpin.Shared.Common.Pagination;
using SiUpin.Shared.Uphs.Common;
using SiUpin.Shared.Users.Queries.Common;

namespace SiUpin.Shared.UphSaranas.Queries
{
    public class GetUphSaranasRequest : PaginationRequest, IRequest<GetUphSaranasResponse>
    {
        public string FilterByName { get; set; }
    }

    public class GetUphSaranasResponse : GeneralResponse
    {
        public PaginationResponse Pagination { get; set; }

        public IList<UphSaranaDTO> Data { get; set; }

        public GetUphSaranasResponse()
        {
            Data = new List<UphSaranaDTO>();
        }
    }

    public class UphSaranaDTO
    {
        public string UphSaranaID { get; set; }
        public string UphID { get; set; }

        public int No { get; set; }
        public string id_sarana { get; set; }
        public string id_uph { get; set; }
        public string nama_uph { get; set; }

        public string tahun { get; set; }
        public string asal_bantuan { get; set; }
        public string lain { get; set; }
        public string nama_alat { get; set; }
        public string kapasitas_terpasang { get; set; }
        public string kapasitas_terpakai { get; set; }
        public string satuan { get; set; }
        public string jenis_mesin { get; set; }
        public string status { get; set; }
        public string alasan { get; set; }
        public string lain_alasan { get; set; }
        public string user { get; set; }

        public UphDTO Uph { get; set; }
        public UserDTO User { get; set; }
    }
}
