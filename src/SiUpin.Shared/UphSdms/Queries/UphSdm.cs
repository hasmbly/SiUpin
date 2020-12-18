using System.Collections.Generic;
using MediatR;
using SiUpin.Shared.Common;
using SiUpin.Shared.Common.Pagination;
using SiUpin.Shared.Uphs.Common;
using SiUpin.Shared.Users.Queries.Common;

namespace SiUpin.Shared.GetUphSdmss.Queries
{
    public class GetUphSdmsRequest : PaginationRequest, IRequest<GetUphSdmsResponse>
    {
        public string FilterByName { get; set; }
    }

    public class GetUphSdmsResponse : GeneralResponse
    {
        public PaginationResponse Pagination { get; set; }

        public IList<UphSdmDTO> Data { get; set; }

        public GetUphSdmsResponse()
        {
            Data = new List<UphSdmDTO>();
        }
    }

    public class UphSdmDTO
    {
        public string UphSdmID { get; set; }
        public string UphID { get; set; }

        public int No { get; set; }
        public string id_sdm { get; set; }
        public string id_uph { get; set; }
        public string nama_uph { get; set; }
        public string jml_sdm { get; set; }
        public string sop { get; set; }
        public string struktur_modal { get; set; }
        public string sumber_modal { get; set; }
        public string jml_modal { get; set; }
        public string nama_pelatihan { get; set; }
        public string penyelenggara { get; set; }
        public string lokasi { get; set; }
        public string tahun { get; set; }
        public string user { get; set; }

        public UphDTO Uph { get; set; }
        public UserDTO User { get; set; }
    }
}
