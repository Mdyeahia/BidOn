using BidOn.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidOn.Data
{
    public class BidOnDBInitializer:CreateDatabaseIfNotExists<BidOnContext>
    {
        protected override void Seed(BidOnContext context)
        {
            SeedRoles(context);
            SeedUsers(context);
        }

        public void SeedRoles(BidOnContext context)
        {
            var rolesInBidOn = new List<IdentityRole>();

            rolesInBidOn.Add(new IdentityRole() {Name="Admin"});
            rolesInBidOn.Add(new IdentityRole() { Name = "Moderator" });
            rolesInBidOn.Add(new IdentityRole() { Name = "User" });

            var rolesStore = new RoleStore<IdentityRole>(context);
            var rolesManager = new RoleManager<IdentityRole>(rolesStore);

            foreach(IdentityRole role in rolesInBidOn)
            {
                if (!rolesManager.RoleExists(role.Name))
                {
                    var result = rolesManager.Create(role);
                    if (result.Succeeded) continue;
                }
            }

        }

        public void SeedUsers(BidOnContext context)
        {
            var usersStore = new UserStore<BidOnUser>(context);
            var usersManager = new UserManager<BidOnUser>(usersStore);

            var admin = new BidOnUser();
            admin.Email = "khan@gmail.com";
            admin.UserName = "admin";
            var password = "admin123";

            if (usersManager.FindByEmail(admin.Email) == null)
            {
                var result = usersManager.Create(admin,password);
                if (result.Succeeded)
                {
                    usersManager.AddToRole(admin.Id, "Admin");
                    usersManager.AddToRole(admin.Id, "Moderator");
                    usersManager.AddToRole(admin.Id, "User");
                }
            }
        }
    }
}
