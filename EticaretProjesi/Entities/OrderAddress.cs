using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class OrderAddress
    {
        public int Id { get; set; }
        public bool AddressType { get; set; }//true gönderilen  teslimat adresi, false fatura adresi
        public string City { get; set; }//şehir
        public string Distrinct { get; set; }
        public string FullAddress { get; set; }
        public string Phone { get; set; }
        public int OrdersId { get; set; }

        public Orders Orders { get; set; }//Her adresin bir siparişi olacak
    }
}
