using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Orders
    {
        public int Id { get; set; }
        public string PaymentType { get; set; } //Ödeme tipi
        public decimal TotalPrice { get; set; } //Toplam Ödenen Ücret
        public decimal TotalDiscount { get; set; } //Toplam indirim
        public int CustomersId { get; set; }
        public DateTime PaymentDate { get; set; } //Ödeme tarihi
        public string OrdersStatus { get; set; }


        public List<OrderDetails> OrderDetails { get; set; }
        public List<OrderAddress> OrderAddresses { get; set; }


    }
}
