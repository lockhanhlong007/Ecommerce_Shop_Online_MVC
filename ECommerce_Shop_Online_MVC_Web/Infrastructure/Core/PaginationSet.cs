using System.Collections.Generic;
using System.Linq;

namespace ECommerce_Shop_Online_MVC_Web.Infrastructure.Core
{
    public class PaginationSet<T>
    {
        public int Page { set; get; }

        public int Count => Items?.Count() ?? 0;

        public int TotalPages { set; get; }
        public int TotalCount { set; get; }
        public IEnumerable<T> Items { set; get; }
    }
}