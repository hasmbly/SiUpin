using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SiUpin.Domain.Common;

namespace SiUpin.Domain.Entities
{
    [Table("uphs")]
    public class Uph : AuditableEntity
    {
        public string UphID { get; set; }

        public string id_uph { get; set; }

#pragma warning disable CS8632
        public string? ProvinsiID { get; set; }
        public string? KotaID { get; set; }
        public string? KecamatanID { get; set; }
        public string? KelurahanID { get; set; }

        public string? ParameterBadanHukumID { get; set; }
        public string? ParameterAdministrasiID { get; set; }
        public string? ParameterBentukLembagaID { get; set; }
        public string? ParameterStatusUphID { get; set; }

        public string Name { get; set; }
        public string Ketua { get; set; }
        public string Handphone { get; set; }
        public string Alamat { get; set; }
        public string TahunBerdiri { get; set; }

        public Provinsi Provinsi { get; set; }
        public Kota Kota { get; set; }
        public Kecamatan Kecamatan { get; set; }
        public Kelurahan Kelurahan { get; set; }

        public ParameterJawaban ParameterBadanHukum { get; set; }
        public ParameterJawaban ParameterAdministrasi { get; set; }
        public ParameterJawaban ParameterBentukLembaga { get; set; }
        public ParameterJawaban ParameterStatusUph { get; set; }

        public IList<UphProduk> UphProduks { get; set; }
        public IList<UphBahanBaku> UphBahanBakus { get; set; }
        public IList<File> Files { get; set; }
        //public IList<UphParameter> UphParameters { get; set; }

        public Uph()
        {
            UphProduks = new List<UphProduk>();
            UphBahanBakus = new List<UphBahanBaku>();
            Files = new List<File>();
            //UphParameters = new List<UphParameter>();
        }
    }
}