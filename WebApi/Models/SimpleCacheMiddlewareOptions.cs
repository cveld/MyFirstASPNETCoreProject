using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class SimpleCacheMiddlewareOptions
    {
        public HashSet<string> UrlList { get; set; }
    }
}
