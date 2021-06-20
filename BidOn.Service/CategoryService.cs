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

        public List<Category>FilterCategory(string searchTerm, int pageNo, int pageSize)
        {
            BidOnContext context = new BidOnContext();
            var category = context.Categories.Include(c=>c.Auctions).AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                category = category.Where(c => c.Name.ToLower().Contains(searchTerm.ToLower()));
            }
            int skipCount = pageSize * ( pageNo - 1);
            return category.OrderByDescending(c => c.Id).Skip(skipCount).Take(pageSize).ToList();
        }

        public int totalCategoryCount(string searchTerm)
        {
            BidOnContext context = new BidOnContext();
            var category = context.Categories.Include(c => c.Auctions).AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                category = category.Where(c => c.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            return category.Count();
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
