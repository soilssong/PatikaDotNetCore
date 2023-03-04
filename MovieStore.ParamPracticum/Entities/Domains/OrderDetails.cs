using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Domains
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public List<Order> Orders { get; set; }

        public int Price { get; set; }

        public Movie movie { get; set; }
         public int MovieId { get; set; }




        //public AppCustomer Customer { get; set; }


        //public int CustomerId { get; set; }

    }
}
