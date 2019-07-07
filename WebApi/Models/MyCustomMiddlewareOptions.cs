using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class MyCustomMiddlewareOptions
    {
        public bool DisplayBefore { get; set; } = true;

        public bool DisplayAfter { get; set; } = true;
    }
}
