using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidOn.Entities
{
    public class Auction:BaseEntity
    {
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        public decimal ActualAmount { get; set; }
        public DateTime StartingTime { get; set; }
        public DateTime EndTime { get; set; }

        public int CategoryId { get; set; }
        public  virtual Category Category { get; set; }

        public List<AuctionPicture> AuctionPictures { get; set; }
    }
}
