using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ProductsImages
    {
        public int Id { get; set; }
        public int ProductsId { get; set; }
        public string Images { get; set; }
        public Products Products{ get; set; }
    }
}
