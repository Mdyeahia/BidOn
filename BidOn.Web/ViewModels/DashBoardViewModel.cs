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
        public List<Bid> Bids { get; set; }

        public int BidOnUserCount { get; set; }

    }
    public class UsersViewModel : PageViewModel
    {
        public string SearchTerm { get; set; }
        public string RoleId { get; set; }
        public List<IdentityRole> Roles { get;set; }
        public Pager pager { get; set; }
        public List<BidOnUser> Users { get; set; }
    }
}