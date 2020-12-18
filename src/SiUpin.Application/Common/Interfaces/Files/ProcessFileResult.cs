using System.Collections.Generic;

namespace SiUpin.Application.Common.Interfaces.Files
{
    public class ProcessFileResult
    {
        public bool IsSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public IList<byte> FileContent { get; set; }
    }
}
