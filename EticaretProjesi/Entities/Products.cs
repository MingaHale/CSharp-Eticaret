using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; } //Fiyat
        public decimal Discount { get; set; } //İndirim
        public int Stock { get; set; }
        public bool Status { get; set; }
        public string Explanation { get; set; } //Açıklama
        public string ImagesName { get; set; }
        public int CategoriesId { get; set; }

        public Categories Categories { get; set; } //Herürün bir kategoriye bağlı olacaktır
        public List<ProductsImages> ProductsImages { get; set; } //Her ürünün birden fazla resmi olabilir

    }
}
