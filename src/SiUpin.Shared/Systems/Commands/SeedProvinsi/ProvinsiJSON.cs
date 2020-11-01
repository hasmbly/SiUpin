using System.Collections.Generic;

namespace SiUpin.Shared.Systems.Commands.SeedProvinsi
{
    public class ProvinsiJSON
    {
        public string table { get; set; }
        public IList<Row> rows { get; set; }
    }

    public class Row
    {
        public string id_provinsi { get; set; }
        public string nama_provinsi { get; set; }
    }
}