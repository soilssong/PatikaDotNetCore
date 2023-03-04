using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Domains
{
    public class Order
    {
       public int Id { get; set; }

        public OrderDetails OrderDetails { get; set; }
        public DateTime PurchaseDate { get; set; }

    }
}
