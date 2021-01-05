using System.Collections.Generic;
using MediatR;

namespace SiUpin.Shared.UphMitras.Queries
{
    public class GetUphMitraClusterGradesRequest : IRequest<GetUphMitraClusterGradesResponse>
    {
    }

    public class GetUphMitraClusterGradesResponse
    {
        public int TotalUph { get; set; }
        public IList<UphMitraClusterDTO> Datas { get; set; } = new List<UphMitraClusterDTO>();
    }

    public class UphMitraClusterDTO
    {
        public int No { get; set; }
        public int ClusterTotal { get; set; }
        public string ClusterGrade { get; set; }
        public int ClusterGradeStar { get; set; }

        public IList<UphMitraClusterByGradeDTO> UphMitras { get; set; } = new List<UphMitraClusterByGradeDTO>();
    }

#pragma warning disable CS8632
    public class UphMitraClusterByGradeDTO
    {
        public int No { get; set; }
        public string UphID { get; set; }
        public string UphName { get; set; }
        public string NamaPerusahaan { get; set; }
        public string JenisKemitraan { get; set; }

        public double? TotalNilai { get; set; }
        public double? TotalNilaiRata2 { get; set; }
        public string ClusterGrade { get; set; }
        public int ClusterGradeStar { get; set; }
    }
}
