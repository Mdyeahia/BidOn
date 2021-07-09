using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BidOn.Entities;
using System.ComponentModel.DataAnnotations;

namespace BidOn.Web.ViewModels
{
    public class AuctionListingViewModel : PageViewModel

    {
        public List<Auction> AllAuctions { get; set; }
        public List<Category> Categories { get; set; }

        public int? CategoryId { get; set; }
        public string SearchTerm { get; set; }
        public int? PageNo { get; set; }

        public Pager pager { get; set; }
        
    }

    public class AuctionsViewModel :PageViewModel

    {
        public List<Auction> AllAuctions { get; set; }
        public List<Auction> PromotedAuctions { get; set; }
        public Auction Auction { get; set; }

        public Bid Bid { get; set; }
        public decimal ActualPrice { get; set; }
    }

    public class CreateAuctionViewModel : PageViewModel
    {
        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(150)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required, Range(1, 20000000)]
        public decimal ActualAmount { get; set; }

        public DateTime? StartingTime { get; set; }
        public DateTime? EndTime { get; set; }

        public string AuctionPictures { get; set; }
        public List<AuctionPicture> AuctionPictureList { get; set; }


        public Auction Auction { get; set; }

        public int categoryId { get; set; }
        public Category Category { get; set;}
        public List<Category> Categories { get; set; }
    }
    public class DetailsAuctionViewModel : PageViewModel
    {
        public Auction Auction { get; set; }
        public BidOnUser LatestBidder { get; set; }
        public decimal BidsAmount { get; set; }
    }



}