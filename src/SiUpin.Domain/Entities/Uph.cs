using System.Collections.Generic;

namespace SiUpin.Domain.Entities
{
    public class Uph
    {
        public string UphID { get; set; }

        public string id_uph { get; set; }

#pragma warning disable CS8632
        public string? ProvinsiID { get; set; }
        public string? KotaID { get; set; }
        public string? KecamatanID { get; set; }
        public string? KelurahanID { get; set; }

        public string Name { get; set; }
        public string Ketua { get; set; }
        public string Handphone { get; set; }
        public string Alamat { get; set; }
        public string TahunBerdiri { get; set; }

        public Provinsi Provinsi { get; set; }
        public Kota Kota { get; set; }
        public Kecamatan Kecamatan { get; set; }
        public Kelurahan Kelurahan { get; set; }

        public IList<UphParameter> UphParameters { get; set; }
        public IList<UphProduk> UphProduks { get; set; }
        public IList<File> Files { get; set; }

        public Uph()
        {
            UphParameters = new List<UphParameter>();
            UphProduks = new List<UphProduk>();
            Files = new List<File>();
        }
    }
}