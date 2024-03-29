﻿using BidOn.Entities;
using BidOn.Service;
using BidOn.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BidOn.Web.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            CategoryLisingtViewModel model = new CategoryLisingtViewModel();
            model.PageTitle = "CategoryTable";
            model.PageDescription = "List of Category";

            return View(model);
        }
        // GET: Auctions
        public ActionResult CategoryTable()
        {
            CategoryLisingtViewModel model = new CategoryLisingtViewModel();



            model.AllCategory = CategoryService.Instance.AllCategories();


            return PartialView(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
            
        }
        [HttpPost]
        public ActionResult Create(CategoryCreateViewModel model)
        {
            Category newCategory = new Category();

            newCategory.Name = model.Name;
            newCategory.Description = model.Description;

            CategoryService.Instance.SaveCategory(newCategory);

            return RedirectToAction("CategoryTable");
        }
        
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var model = new CategoryCreateViewModel();

            model.category= CategoryService.Instance.CategoryById(Id);

            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Edit(CategoryCreateViewModel model)
        {
            Category editCategory = new Category();

            editCategory.Name = model.Name;
            editCategory.Description = model.Description;

            CategoryService.Instance.UpdateCategory(editCategory);

            return RedirectToAction("CategoryTable");
        }
        public ActionResult Delete(int Id)
        {
            CategoryService.Instance.DeleteCategory(Id);

            return RedirectToAction("CategoryTable");
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {

            CategoryDetailsViewModel model = new CategoryDetailsViewModel();

            model.category=CategoryService.Instance.CategoryById(Id);

            return PartialView(model);
        }


    }
  
}