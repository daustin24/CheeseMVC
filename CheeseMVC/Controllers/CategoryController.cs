using System;
using System.Linq;
using CheeseMVC.Data;
using CheeseMVC.Models;
using CheeseMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace CheeseMVC.Controllers
{
    public class CategoryController : Controller 
    {
        private readonly CheeseDbContext context;

        public CategoryController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(context.Categories.ToList()); 
        }


        // GET  /Category/Add
        public IActionResult Add()
        {
            AddCategoryViewModel addCategoryViewModel = new AddCategoryViewModel(); 

            return View(addCategoryViewModel); 
        }


        // POST /Category/Add
        [HttpPost]
        public IActionResult Add(AddCategoryViewModel vm)
        {
            if (ModelState.IsValid)
            {
                CheeseCategory newCategory = new CheeseCategory
                {
                    Name = vm.Name
                };

                context.Categories.Add(newCategory);
                context.SaveChanges();

                return Redirect("Index");
            }

            return View(vm);
        }

    }
}
