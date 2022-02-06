using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Product.Models
{
    public class Products
    {
        public List<Entity> Entities { get; set; }
    }
    public class Fields
    {
        public string Field { get; set; }
        public Boolean IsRequired { get; set; }
        public int MaxLength { get; set; }
        public string Source { get; set; }
    }
    public class Entity
    {
        public string EntityName { get; set; }
        public List<Fields> Fields { get;set;}
    }
}