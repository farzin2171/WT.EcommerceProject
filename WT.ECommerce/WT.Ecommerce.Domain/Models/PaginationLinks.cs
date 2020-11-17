using System;

namespace WT.Ecommerce.Domain.Models
{
    public class PaginationLinks
    {
        
        public PaginationLinks(string endPoint,
                               int recordCount,
                               int skip,
                               int limit)
        {
            RecordCount = recordCount;
            PageCount = (int)Math.Ceiling((double)recordCount / limit) - 1;
            Self = $"{endPoint}?skip={skip}&limit={limit}";
            First= $"{endPoint}?skip=0&limit={limit}";
            Prev = skip == 0 ? string.Empty : $"{endPoint}?skip={skip - limit}&limit={limit}";
            Next = skip < PageCount * limit ? $"{endPoint}?skip={skip +limit}&limit={limit}":string.Empty;
            Last = $"{endPoint}?skip={PageCount * limit}&limit={limit}";
        }

        public string Self { get; private set; }
        public string First { get; private set; }
        public string Last { get; private set; }
        public string Prev { get; private set; }
        public string Next { get; private set; }
        public int RecordCount { get; private set; }
        public int PageCount { get; private set; }

    }
}
