using System.Collections.Generic;

namespace SiUpin.Shared.Files.Queries.GetFiles
{
    public class GetFilesResponse
    {
        public bool IsSuccessful { get; set; }
        public IList<File> Files { get; set; }

        public GetFilesResponse()
        {
            Files = new List<File>();
        }
    }
}
