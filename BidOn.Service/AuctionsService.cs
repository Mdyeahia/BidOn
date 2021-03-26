using BidOn.Data;
using BidOn.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidOn.Service
{
    public class AuctionsService
    {
        public Auction GetAuctionById(int Id)
        {
            BidOnContext context = new BidOnContext();


            return context.Auctions.Find(Id);

        }
        public List<Auction> GetAllAuction()
        {
            BidOnContext context = new BidOnContext();
            return context.Auctions.ToList();

        }

        public void SaveAuction(Auction auction)
        {
            BidOnContext context = new BidOnContext();

            context.Auctions.Add(auction);
            context.SaveChanges();

        }

        

        public void UpdateAuction(Auction auction)
        {
            BidOnContext context = new BidOnContext();

            context.Entry(auction).State = EntityState.Modified;
            context.SaveChanges();

        }
        public void DeleteAuction(int Id)
        {
            BidOnContext context = new BidOnContext();
            var deleteAuction = context.Auctions.Find(Id);

            context.Entry(deleteAuction).State = EntityState.Deleted;
            context.SaveChanges();

        }
    }
}
