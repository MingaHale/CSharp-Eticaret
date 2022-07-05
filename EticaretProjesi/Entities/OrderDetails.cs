using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Images { get; set; }
        public int Piece { get; set; } //Adet
        public int OrdersId { get; set; }
        public int ProductsId { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public Orders Orders { get; set; } //Her ürünün bir faturası olacaktır
        
    }
}
