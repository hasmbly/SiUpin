namespace SiUpin.Shared.Systems.Commands.SeedRole
{
    public class RoleJSON
    {
        public string table { get; set; }
        public Row[] rows { get; set; }
    }

    public class Row
    {
        public string id_role { get; set; }
        public string nama_role { get; set; }
    }

}