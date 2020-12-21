using System.Collections.Generic;

namespace SiUpin.Shared.Uphs.Queries.GetUphClusterGrades
{
    public class GetUphClusterGradesResponse
    {
        public int TotalUph { get; set; }
        public IList<UphClusterDTO> Datas { get; set; }

        public GetUphClusterGradesResponse()
        {
            Datas = new List<UphClusterDTO>();
        }
    }

    public class UphClusterDTO
    {
        public int No { get; set; }
        public int ClusterTotal { get; set; }
        public string ClusterGrade { get; set; }
        public int ClusterGradeStar { get; set; }

        public IList<UphClusterByGradeDTO> Uphs { get; set; } = new List<UphClusterByGradeDTO>();
    }

#pragma warning disable CS8632
    public class UphClusterByGradeDTO
    {
        public int No { get; set; }
        public string UphID { get; set; }
        public string Name { get; set; }
        public string? Provinsi { get; set; }
        public string Handphone { get; set; }
        public string Alamat { get; set; }

        public double? TotalNilai { get; set; }
        public double? TotalNilaiRata2 { get; set; }
        public string ClusterGrade { get; set; }
        public int ClusterGradeStar { get; set; }
    }
}
