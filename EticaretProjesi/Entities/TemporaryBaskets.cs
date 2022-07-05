using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TemporaryBaskets
    {
        public int Id { get; set; }
        public int ProductsId { get; set; }
        public string Name { get; set; }
        public string Images { get; set; }
        public int Piece { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int BasketCookies { get; set; }
    }
}
