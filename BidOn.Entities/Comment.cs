using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidOn.Entities
{
    public class Comment:BaseEntity
    {
        public string Text { get; set; }
        public int Rating { get; set; }
        public DateTime Timestamp { get; set; }

        public string UserId { get; set; }
        public BidOnUser User { get; set; }

        public int EntityId { get; set; }//id of auction,blog,ex....
        public int RecordId { get; set; }//id of entity
    }
}
