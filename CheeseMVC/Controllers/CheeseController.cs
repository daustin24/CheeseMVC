using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Models;
using CheeseMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            List<Cheese> cheeses = CheeseData.GetAll(); 

            // ViewBag.cheeses = CheeseData.GetAll();
            // ViewData["cheese"] = CheeseData.GetAll();

            return View(cheeses); 
        }


        
        [HttpPost]
        [Route("/Cheese/Remove")]
        public IActionResult Remove (int[] cheeseIds) 
        {
            foreach (int cheeseId in cheeseIds)
            {
                CheeseData.Remove(cheeseId);
            }
            
            return Redirect("/Cheese"); 
        }





        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel();

            return View(addCheeseViewModel);
        }



        
        [HttpPost]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            if (ModelState.IsValid)
            {

                Cheese newCheese = addCheeseViewModel.CreateCheese();

                CheeseData.Add(newCheese);
                return Redirect("/Cheese");
            }

            return View(addCheeseViewModel); 
            
        }


        // GET /Cheese/Edit?cheeseId=#
        public IActionResult Edit(int cheeseId)
        {
            Cheese ch = CheeseData.GetById(cheeseId);


            AddEditCheeseViewModel addEditCheeseViewModel = new AddEditCheeseViewModel(ch); 
            
            

            return View(addEditCheeseViewModel); 
        }


        // POST /Cheese/Edit 
        [HttpPost]
        public IActionResult Edit (AddEditCheeseViewModel addEditCheeseViewModel)
        {
            // Validate the form data
            if (ModelState.IsValid)
            {
                Cheese ch = CheeseData.GetById(addEditCheeseViewModel.CheeseId);
                ch.Name = addEditCheeseViewModel.Name;
                ch.Description = addEditCheeseViewModel.Description;
                ch.Type = addEditCheeseViewModel.Type;
                ch.Rating = addEditCheeseViewModel.Rating;

                return Redirect("/Cheese");
            }

            return View(addEditCheeseViewModel); 
 
        }

      
    }

    
}


