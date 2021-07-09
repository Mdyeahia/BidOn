using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidOn.Entities
{
    public class Auction:BaseEntity
    {
        [Required,MinLength(3),MaxLength(150)]
        public string Title { get; set; }
        
        public string Description { get; set; }

        [Required,Range(1,20000000)]
        public decimal ActualAmount { get; set; }

        public DateTime? StartingTime { get; set; }
        public DateTime? EndTime { get; set; }

        public int CategoryId { get; set; }
        public  virtual Category Category { get; set; }


        public  List<AuctionPicture> AuctionPictures { get; set; }


        public virtual  List<Bid> Bids { get; set; }
    }
}
