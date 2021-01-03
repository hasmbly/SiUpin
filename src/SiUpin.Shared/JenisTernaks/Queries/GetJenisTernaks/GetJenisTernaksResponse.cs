using System.Collections.Generic;
using SiUpin.Shared.JenisTernaks.Queries.Common;

namespace SiUpin.Shared.JenisTernaks.Queries.GetJenisTernaks
{
    public class GetJenisTernaksResponse
    {
        public IList<JenisTernakDTO> Data { get; set; }

        public GetJenisTernaksResponse()
        {
            Data = new List<JenisTernakDTO>();
        }
    }
}
