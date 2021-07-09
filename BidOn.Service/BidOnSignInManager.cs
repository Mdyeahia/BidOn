using BidOn.Entities;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BidOn.Service
{
    // Configure the application sign-in manager which is used in this application.
    public class BidOnSignInManager : SignInManager<BidOnUser, string>
    {
        public BidOnSignInManager(BidOnUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(BidOnUser user)
        {
            return user.GenerateUserIdentityAsync((BidOnUserManager)UserManager);
        }

        public static BidOnSignInManager Create(IdentityFactoryOptions<BidOnSignInManager> options, IOwinContext context)
        {
            return new BidOnSignInManager(context.GetUserManager<BidOnUserManager>(), context.Authentication);
        }
    }
}
