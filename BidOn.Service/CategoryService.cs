using BidOn.Data;
using BidOn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BidOn.Service
{
    public class CategoryService
    {
        #region Singleton
        public static CategoryService Instance
        {
            get
            {
                if (instance == null) instance = new CategoryService();

                return instance;
            }
        }
        private static CategoryService instance { get; set; }

        private CategoryService()
        {
        }

        #endregion



        public Category CategoryById(int Id)
        {
            BidOnContext context = new BidOnContext();

            return context.Categories.Find(Id);
        }

        public List<Category> AllCategories()
        {
            BidOnContext context = new BidOnContext();

            return context.Categories.Include(c=>c.Auctions).ToList();
        }

        public void SaveCategory(Category category)
        {
            BidOnContext context = new BidOnContext();

            context.Categories.Add(category);
            context.SaveChanges();
        }

        public void DeleteCategory(int Id)
        {
            BidOnContext context = new BidOnContext();

            var Deletecategory = context.Categories.Find(Id);
            context.Entry(Deletecategory).State = EntityState.Deleted;

            context.SaveChanges();
        }
        public void UpdateCategory(Category category)
        {
            BidOnContext context = new BidOnContext();

            context.Entry(category).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
