using System;

namespace SiUpin.Shared.Common.Pagination
{
    public class PaginationResponse
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;

        public int TotalPages
        {
            get => (int)Math.Ceiling(TotalCount / (double)PageSize);
        }
    }
}
