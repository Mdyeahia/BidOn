using BidOn.Data;
using BidOn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidOn.Service
{
    public class BidsService
    {
        #region Singleton
        public static BidsService Instance
        {
            get
            {
                if (instance == null) instance = new BidsService();

                return instance;
            }
        }
        private static BidsService instance { get; set; }

        private BidsService()
        {
        }

        #endregion

        public bool AddBid(Bid bid)
        {
            BidOnContext context = new BidOnContext();

            context.Bids.Add(bid);

            return context.SaveChanges() > 0;
        }
    }

   
}
