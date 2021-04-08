using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BidOn.Entities;

namespace BidOn.Web.ViewModels
{
    public class AuctionListingViewModel : PageViewModel

    {
        public List<Auction> AllAuctions { get; set; }
        
    }

    public class AuctionsViewModel :PageViewModel

    {
        public List<Auction> AllAuctions { get; set; }
        public List<Auction> PromotedAuctions { get; set; }

        public Auction Auction { get; set; }
    }

    public class CreateAuctionViewModel : PageViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }
        public decimal ActualAmount { get; set; }
        public DateTime StartingTime { get; set; }
        public DateTime EndTime { get; set; }

        public string AuctionPictures { get; set; }
    }

    
}