using System.Collections.Generic;
using SiUpin.Shared.Common;
using SiUpin.Shared.Common.Pagination;

namespace SiUpin.Shared.Uphs.Queries.GetUphClusterByGrade
{
    public class GetUphClusterByGradeResponse : GeneralResponse
    {
        public PaginationResponse Pagination { get; set; }
        public IList<ClustersUphByGradeDTO> Data { get; set; } = new List<ClustersUphByGradeDTO>();
    }

#pragma warning disable CS8632
    public class ClustersUphByGradeDTO
    {
        public int No { get; set; }

        public string UphID { get; set; }
        public string Name { get; set; }
        public string? Provinsi { get; set; }
        public string Handphone { get; set; }
        public string Alamat { get; set; }

        public decimal TotalNilai { get; set; }
        public decimal TotalNilaiRata2 { get; set; }
        public string ClusterGrade { get; set; }
        public int ClusterGradeStar { get; set; }
    }
}
