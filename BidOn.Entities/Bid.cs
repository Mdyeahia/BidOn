using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidOn.Entities
{
    public class Bid:BaseEntity
    {
        public decimal BidAmount { get; set; }

        public DateTime Timestamp { get; set; }

        //nav props 
        public int AuctionId { get; set; }
        public Auction Auction { get; set; }

        public string UserId { get; set; }
        public virtual BidOnUser User { get; set; }
    }
}
