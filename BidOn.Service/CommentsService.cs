using BidOn.Data;
using BidOn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace BidOn.Service
{
    public class CommentsService
    {
        #region Singleton
        public static CommentsService Instance
        {
            get
            {
                if (instance == null) instance = new CommentsService();

                return instance;
            }
        }
        private static CommentsService instance { get; set; }

        private CommentsService()
        {
        }

        #endregion

        public bool LeaveComment(Comment comment)
        {
            BidOnContext context = new BidOnContext();

            context.Comments.Add(comment);

            return context.SaveChanges() > 0;
        }
        public List<Comment> GetComments(int entityId,int recordId)
        {
            BidOnContext context = new BidOnContext();

            return context.Comments.Include(c =>c.User).Where(c => c.EntityId == entityId && c.RecordId == recordId).ToList();

        }
        public void DeleteEntityComments(int entityId, int recordId)
        {
            BidOnContext context = new BidOnContext();

            var auctioncomments = context.Comments.Where(c => c.EntityId == entityId && c.RecordId == recordId);
            
            foreach (var comment in auctioncomments)
            {
                context.Entry(comment).State = EntityState.Deleted;
            }
            context.SaveChanges();
        }
    }
}
