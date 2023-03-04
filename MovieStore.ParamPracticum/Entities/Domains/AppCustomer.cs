using Entities.Domains.ManyToMany;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Domains
{
    public class AppCustomer : BaseEntity
    {


        public string UserName { get; set; }

        public string Pasword { get; set; }

        public List<Order> Orders { get; set; }

         
        public AppRole AppRole { get; set; }

        public int AppRoleId { get; set; }

        public ICollection <CustomerGenre> FavouriteGenres { get; set; }


    }
}
