using BidOn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BidOn.Web.ViewModels
{
    public class CategoryLisingtViewModel:PageViewModel
    {
        public List<Category> AllCategory { get; set; }
        public List<Action> AllAuction { get; set; }
        public string SearchTerm { get; set; }
        public Pager Pager { get; set; }
    }
    public class CategoryCreateViewModel : PageViewModel
    {

        public string Name { get; set; }
        public string Description { get; set; }

        public Category category { get; set; }

        public List<Category> AllCategory { get; set; }
        public List<Action> AllAuction { get; set; }
    }
    public class CategoryDetailsViewModel : PageViewModel
    {

        public string Name { get; set; }
        public string Description { get; set; }

        public Category category { get; set; }

        public List<Action> AllAuction { get; set; }
    }

}