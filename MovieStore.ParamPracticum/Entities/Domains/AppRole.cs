using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Domains
{
    public class AppRole : BaseEntity
    {

        //public int Id { get; set; }

        public string Definition { get; set; }

        public List<AppCustomer> AppCustomers { get; set; }
    }
}
