using System.Collections.Generic;
using MediatR;
using SiUpin.Shared.Common;
using SiUpin.Shared.Common.Pagination;
using SiUpin.Shared.Uphs.Common;

namespace SiUpin.Shared.UphProduksis.Queries
{
    public class GetUphProduksisRequest : PaginationRequest, IRequest<GetUphProduksisResponse>
    {
        public string FilterByName { get; set; }
    }

    public class GetUphProduksisResponse : GeneralResponse
    {
        public PaginationResponse Pagination { get; set; }

        public IList<UphProduksiDTO> Data { get; set; }

        public GetUphProduksisResponse()
        {
            Data = new List<UphProduksiDTO>();
        }
    }

    public class UphProduksiDTO
    {
        public string UphProduksiID { get; set; }
        public string UphID { get; set; }

        public int No { get; set; }
        public string id_produksi { get; set; }
        public string id_uph { get; set; }
        public string nama_uph { get; set; }
        public string bahan_baku { get; set; }
        public string jml_produksi { get; set; }
        public string satuan { get; set; }
        public string izin_edar { get; set; }
        public string jml_edar { get; set; }
        public string sertifikat { get; set; }
        public string jml_sertifikat { get; set; }
        public string gmp { get; set; }
        public string jml_gmp { get; set; }
        public string jml_hari_produksi { get; set; }
        public string user { get; set; }

        public UphDTO Uph { get; set; }
    }
}
