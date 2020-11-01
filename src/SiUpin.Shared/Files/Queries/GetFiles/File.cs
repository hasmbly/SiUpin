namespace SiUpin.Shared.Files.Queries.GetFiles
{
    public class File
    {
        public string FileID { get; set; }
        public string EntityID { get; set; }
        public string EntityType { get; set; }

        public string Name { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
    }
}
