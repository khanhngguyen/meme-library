using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemeLibrary.Domain.src.Entities
{
    public class QueryOptions
    {
        public string Search { get; set; } = string.Empty;
        public string OrderBy { get; set; } = string.Empty;
        public int PageNumber { get; set; } = 0;
        public int PageSize { get; set; } = 20;
    }
}