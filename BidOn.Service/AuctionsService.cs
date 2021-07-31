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
        #region Singleton
        public static AuctionsService Instance
        {
            get
            {
                if (instance == null) instance = new AuctionsService();

                return instance;
            }
        }
        private static AuctionsService instance { get; set; }

        private AuctionsService()
        {
        }

        #endregion

        public Auction GetAuctionById(int Id)
        {
            BidOnContext context = new BidOnContext();


            return context.Auctions.Include(a=>a.AuctionPictures).Include("AuctionPictures.Picture").Where(a=>a.Id==Id).First();

        }
        public List<Auction> GetAllAuction()
        {
            BidOnContext context = new BidOnContext();

            return context.Auctions.Include(a => a.AuctionPictures)
                .Include("AuctionPictures.Picture")
                .Include(a=>a.Bids)
                .ToList();
        }
        public List<Auction> FilterAuctions(int? categoryId, string searchTerm, int pageNo,int pageSize)
        {
            var context = new BidOnContext();

            var auction = context.Auctions.Include(a => a.Category).AsQueryable();
            if (categoryId.HasValue && categoryId.Value > 0)
            {
                auction = auction.Where(x => x.CategoryId == categoryId.Value);
            }
            if (!string.IsNullOrEmpty(searchTerm))
            {
                auction = auction.Where(x => x.Title.ToLower().Contains(searchTerm.ToLower()));
            }
            int skipCount = pageSize * (pageNo - 1);

            return auction.OrderByDescending(a => a.Id).Skip(skipCount).Take(pageSize).ToList();

        }
        public int GetAuctionCount(int? categoryId, string searchTerm)
        {
            var context = new BidOnContext();

            var auction = context.Auctions.Include(a => a.Category).AsQueryable();
            if (categoryId.HasValue && categoryId.Value > 0)
            {
                auction = auction.Where(x => x.CategoryId == categoryId.Value);
            }
            if (!string.IsNullOrEmpty(searchTerm))
            {
                auction = auction.Where(x => x.Title.ToLower().Contains(searchTerm.ToLower()));
            }


            return auction.Count();

        }
        public List<Auction> GetPromotedAuctions()
        {
            BidOnContext context = new BidOnContext();

            return context.Auctions.Take(6).Include("AuctionPictures.Picture")
                .Include(b=>b.Bids)
                .ToList();

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

            var exitAuction = context.Auctions.Where(x => x.Id == auction.Id).Include(x => x.AuctionPictures).First();
            context.AuctionPictures.RemoveRange(exitAuction.AuctionPictures);

            context.Entry(exitAuction).CurrentValues.SetValues(auction);

            context.AuctionPictures.AddRange(auction.AuctionPictures);
            
            context.SaveChanges();

        }
        public void DeleteAuction(int Id)
        {
            BidOnContext context = new BidOnContext();
            var deleteAuction = context.Auctions.Find(Id);

            context.Entry(deleteAuction).State = EntityState.Deleted;
            //context.Entry(auction).State = EntityState.Deleted;
            context.SaveChanges();

        }
    }
}
