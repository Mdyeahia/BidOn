using BidOn.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidOn.Data
{
    public class BidOnContext : IdentityDbContext<BidOnUser>
    {
        public BidOnContext() : base("BidOnConnection")
        {
            
        }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<AuctionPicture> AuctionPictures { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public static BidOnContext Create()
        {
            return new BidOnContext();
        }

    }
}
