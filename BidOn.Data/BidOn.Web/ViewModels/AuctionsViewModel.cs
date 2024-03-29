﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BidOn.Entities;

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
    }

    public class CreateAuctionViewModel : PageViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public decimal ActualAmount { get; set; }
        public DateTime StartingTime { get; set; }
        public DateTime EndTime { get; set; }

        public string AuctionPictures { get; set; }
        public List<AuctionPicture> AuctionPictureList { get; set; }


        public Auction Auction { get; set; }

        public int categoryId { get; set; }
        public Category Category { get; set;}
        public List<Category> Categories { get; set; }
    }

    
}