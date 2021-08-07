using BidOn.Entities;
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
}