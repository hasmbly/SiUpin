using System.Collections.Generic;
using MediatR;
using SiUpin.Shared.Common;
using SiUpin.Shared.Common.Pagination;
using SiUpin.Shared.UphBahanBakus.Common;

namespace SiUpin.Shared.UphBahanBakus.Queries
{
    public class GetUphBahanBakusRequest : PaginationRequest, IRequest<GetUphBahanBakusResponse>
    {
        public string FilterByName { get; set; }
    }

    public class GetUphBahanBakusResponse : GeneralResponse
    {
        public PaginationResponse Pagination { get; set; }

        public IList<UphBahanBakuDTO> Data { get; set; }

        public GetUphBahanBakusResponse()
        {
            Data = new List<UphBahanBakuDTO>();
        }
    }

    //public class UphBahanBakuDTO
    //{
    //    public string UphBahanBakuID { get; set; }
    //    public string UphID { get; set; }

    //    public int No { get; set; }
    //    public string id_bahan_baku { get; set; }
    //    public string id_uph { get; set; }

    //    public string JenisTernakID { get; set; }
    //    public string JenisKomoditiID { get; set; }
    //    public string SatuanID { get; set; }

    //    public string TotalKebutuhan { get; set; }
    //    public string AsalBahanBaku { get; set; }
    //    public string Nilai { get; set; }
    //    public string CreatedBy { get; set; }

    //    public JenisTernakDTO JenisTernak { get; set; }
    //    public JenisKomoditiDTO JenisKomoditi { get; set; }
    //    public SatuanDTO Satuan { get; set; }
    //    public UphDTO Uph { get; set; }
    //}
}
