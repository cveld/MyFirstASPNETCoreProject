using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class CacheItem
    {
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public string ContentType { get; set; }
    }
}
