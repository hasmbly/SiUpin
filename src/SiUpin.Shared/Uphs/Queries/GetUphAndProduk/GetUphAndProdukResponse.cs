using System.Collections.Generic;

namespace SiUpin.Shared.Uphs.Queries.GetUphAndProduk
{
    public class GetUphAndProdukResponse
    {
        public string UphID { get; set; }
        public string Name { get; set; }
        public string Ketua { get; set; }
        public string Handphone { get; set; }
        public string Alamat { get; set; }
        public string TahunBerdiri { get; set; }

        public string ProvinsiID { get; set; }
        public string KotaID { get; set; }
        public string KecamatanID { get; set; }
        public string KelurahanID { get; set; }

        public string ParameterBadanHukumID { get; set; }
        public string ParameterAdministrasiID { get; set; }
        public string ParameterBentukLembagaID { get; set; }
        public string ParameterStatusUphID { get; set; }

        public IList<UphProdukDTO> UphProduks { get; set; } = new List<UphProdukDTO>();
        //public NecessaryDataDTO NecessaryData { get; set; }
    }

#pragma warning disable CS8632
    public class UphProdukDTO
    {
        public string UphID { get; set; }
        public string UphProdukID { get; set; }
        public string Name { get; set; }
        public string Harga { get; set; }
        public int Berat { get; set; }
        public string Description { get; set; }

        public string? ProdukOlahanID { get; set; }
        public string? JenisTernakID { get; set; }
        public string? SatuanID { get; set; }

        public FileDTO File { get; set; } = new FileDTO();
    }

    public class FileDTO
    {
        public string FileID { get; set; }
        public string EntityID { get; set; }
        public string EntityType { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }

    //public class NecessaryDataDTO
    //{
    //    public IList<Provinsi> Provinsis { get; set; } = new List<Provinsi>();
    //    public IList<Kota> Kotas { get; set; } = new List<Kota>();
    //    public IList<Kecamatan> Kecamatans { get; set; } = new List<Kecamatan>();
    //    public IList<Kelurahan> Kelurahans { get; set; } = new List<Kelurahan>();

    //    public IList<ParameterJawaban> ParameterBadanHukums { get; set; } = new List<ParameterJawaban>();
    //    public IList<ParameterJawaban> ParameterAdministrasis { get; set; } = new List<ParameterJawaban>();
    //    public IList<ParameterJawaban> ParameterBentukLembagas { get; set; } = new List<ParameterJawaban>();
    //    public IList<ParameterJawaban> ParameterStatusUphs { get; set; } = new List<ParameterJawaban>();

    //    public IList<ProdukOlahan> ProdukOlahans { get; set; } = new List<ProdukOlahan>();
    //    public IList<JenisTernak> JenisTernaks { get; set; } = new List<JenisTernak>();
    //    public IList<Satuan> Satuans { get; set; } = new List<Satuan>();
    //}
}
