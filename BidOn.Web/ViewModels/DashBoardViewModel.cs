using BidOn.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BidOn.Web.ViewModels
{
    public class DashBoardViewModel:PageViewModel
    {
        public List<Auction> Auctions { get; set; }
        public List<Category> Categories { get; set; }
        public List<Bid> Bids { get; set; }

        public List<IdentityRole> BidOnRoles { get; set; }
        public List<Comment> BidOnComment { get; set; }
        public int BidOnUserCount { get; set; }

    }
    public class UsersViewModel : PageViewModel
    {
        public string SearchTerm { get; set; }
        public string RoleId { get; set; }
        public List<IdentityRole> Roles { get;set; }

        public List<BidOnUser> Admin { get; set; }
        public List<BidOnUser> Modarator { get; set; }
        
        public Pager pager { get; set; }
        public List<BidOnUser> Users { get; set; }
    }
    public class UserDetailsViewModel : PageViewModel
    {
        public string userId { get; set; }
        public BidOnUser User { get; set; }

        public List<IdentityRole> AvailableRoles { get; set;}
        public List<IdentityRole> UserRoles { get; set; }

    }

    public class RolesViewModel : PageViewModel
    {
        public string SearchTerm { get; set; }
        public List<IdentityRole> Roles { get; set; }
        public string RoleId { get; set; }
        public Pager pager { get; set; }
        public List<BidOnUser> Users { get; set; }
    }
}