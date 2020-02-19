using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication1.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public System.Data.Entity.DbSet<WebApplication1.Models.Customer> Customers { get; set; }


        public System.Data.Entity.DbSet<WebApplication1.Models.Mechanic> Mechanics { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.Message> Messages { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.RepairOrder> RepairOrders { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.Shop> Shops { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.Review> Reviews { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


    }
}