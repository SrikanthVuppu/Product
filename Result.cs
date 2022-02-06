using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Product.Models
{
    public class Result
    {
        public string statusCode { get; set; }
        public string statusMessage { get; set; }
        public object data { get; set; }
    }
}