using System.Collections.Generic;
using MediatR;
using SiUpin.Shared.Common;
using SiUpin.Shared.Common.Pagination;
using SiUpin.Shared.Uphs.Common;

namespace SiUpin.Shared.UphMitras.Queries
{
    public class GetUphMitrasRequest : PaginationRequest, IRequest<GetUphMitrasResponse>
    {
        public string FilterByName { get; set; }
    }

    public class GetUphMitrasResponse : GeneralResponse
    {
        public PaginationResponse Pagination { get; set; }

        public IList<UphMitrasDTO> Data { get; set; }

        public GetUphMitrasResponse()
        {
            Data = new List<UphMitrasDTO>();
        }
    }

    public class UphMitrasDTO
    {
        public string UphMitraID { get; set; }
        public string UphID { get; set; }

        public int No { get; set; }
        public string id_mitra { get; set; }
        public string id_uph { get; set; }
        public string bermitra { get; set; }
        public string jenis_usaha { get; set; }
        public string nama_perusahaan { get; set; }
        public string alamat { get; set; }
        public string penanggungjawab { get; set; }
        public string no_hp { get; set; }
        public string jenis_mitra { get; set; }
        public string lembaga { get; set; }
        public string lembaga_lain { get; set; }
        public string nilai_lembaga { get; set; }
        public string nilai_mitra { get; set; }
        public string detail_bahan { get; set; }
        public string lain_kopetensi { get; set; }
        public string satuan_bahan { get; set; }
        public string detail_mitra { get; set; }
        public string detail_sarana { get; set; }
        public string nilai_sarana { get; set; }
        public string detail_kopetensi { get; set; }
        public string detail_fasilitasi { get; set; }
        public string detail_promosi { get; set; }
        public string nilai_promosi { get; set; }
        public string manajemen_limbah { get; set; }
        public string sasaran { get; set; }
        public string perjanjian { get; set; }
        public string upload_doc { get; set; }
        public string awal_periode { get; set; }
        public string akhir_periode { get; set; }
        public string status { get; set; }
        public string user { get; set; }

        public UphDTO Uph { get; set; }
    }
}
