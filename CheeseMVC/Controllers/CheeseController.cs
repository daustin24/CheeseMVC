using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Data;
using CheeseMVC.Models;
using CheeseMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        private readonly CheeseDbContext context;

        public CheeseController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }



        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index() 
        {
            IList<Cheese> cheeses = context.Cheeses.Include(c => c.Category).ToList();

            //List<Cheese> cheeses = context.Cheeses.ToList(); 

            // ViewBag.cheeses = CheeseData.GetAll();
            // ViewData["cheese"] = CheeseData.GetAll();

            return View(cheeses);  
        }



        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel(context.Categories.ToList());
            

            return View(addCheeseViewModel);
        }


        
        [HttpPost]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            if (ModelState.IsValid)
            {
                CheeseCategory newCheeseCategory =
                    context.Categories.Single(c => c.ID == addCheeseViewModel.CategoryID);

                Cheese newCheese = new Cheese
                {
                    Name = addCheeseViewModel.Name,
                    Description = addCheeseViewModel.Description,
                    Rating = addCheeseViewModel.Rating,
                    Category = newCheeseCategory
                };

                context.Cheeses.Add(newCheese);
                context.SaveChanges();

                return Redirect("/Cheese");
            }

            return View(addCheeseViewModel); 
            
        }



        [HttpPost]
        [Route("/Cheese/Remove")]
        public IActionResult Remove(int[] cheeseIds)
        {
            foreach (int cheeseId in cheeseIds)
            {
                Cheese theCheese = context.Cheeses.Single(c => c.ID == cheeseId);
                context.Cheeses.Remove(theCheese);
            }

            context.SaveChanges();

            return Redirect("/Cheese");
        }



        // GET /Cheese/Edit?cheeseId=#
        public IActionResult Edit(int ID)
        {

            Cheese ch = context.Cheeses.Single(c => c.ID == ID);

                
            AddEditCheeseViewModel addEditCheeseViewModel = new AddEditCheeseViewModel(ch, context.Categories.ToList()); 
            
            

            return View(addEditCheeseViewModel); 
        }


        // POST /Cheese/Edit 
        [HttpPost]
        public IActionResult Edit (AddEditCheeseViewModel vm)
        {
            // Validate the form data
            if (ModelState.IsValid)
            {
                Cheese ch = context.Cheeses.Single(c => c.ID == vm.CheeseId); 
                ch.Name = vm.Name;
                ch.Description = vm.Description;
                ch.CategoryID = vm.CategoryID;
                ch.Rating = vm.Rating;

                context.SaveChanges(); 

                return Redirect("/Cheese");
            }

            return View(vm); 
 
        }

      
    }

    
}


