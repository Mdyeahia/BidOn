using BidOn.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidOn.Service
{
    public class BidOnRoleManager:RoleManager<IdentityRole>
    {
        public BidOnRoleManager(IRoleStore<IdentityRole, string> roleStore):base(roleStore)
        {

        }
        public static BidOnRoleManager Create(IdentityFactoryOptions<BidOnRoleManager> options, IOwinContext context)
        {
            return new BidOnRoleManager(new RoleStore<IdentityRole>(context.Get<BidOnContext>()));
        }
    }
}
