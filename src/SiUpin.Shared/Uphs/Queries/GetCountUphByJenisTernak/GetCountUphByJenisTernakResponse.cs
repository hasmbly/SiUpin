using System.Collections.Generic;

namespace SiUpin.Shared.Uphs.Queries.GetCountUphByJenisTernak
{
    public class GetCountUphByJenisTernakResponse
    {
        public IList<UphByJenisTernakDTO> UphByJenisTernaks { get; set; } = new List<UphByJenisTernakDTO>();
    }
}
