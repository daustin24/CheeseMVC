using System;
using System.Collections.Generic;
using System.Linq;
using CheeseMVC.Data;
using CheeseMVC.Models;
using CheeseMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CheeseMVC.Controllers
{
    public class MenuController : Controller
    {
        private readonly CheeseDbContext context;

        public MenuController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(context.Menus.ToList());  
        }



        public IActionResult Add()
        {
            AddMenuViewModel addMenuViewModel = new AddMenuViewModel();

            return View(addMenuViewModel); 
        }



        [HttpPost]
        public IActionResult Add(AddMenuViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Menu newMenu = new Menu
                {
                    Name = vm.Name
                };

                context.Menus.Add(newMenu);
                context.SaveChanges();

                return Redirect("/Menu/ViewMenu/" + newMenu.ID);
            }

            return View(vm);
        }




        public IActionResult ViewMenu(int id)
        {
            Menu m = context.Menus.Single(c => c.ID == id);

            List<CheeseMenu> items = context
                .CheeseMenus
                .Include(item => item.Cheese)
                .Where(cm => cm.MenuID == id)
                .ToList();

            ViewMenuViewModel vm = new ViewMenuViewModel(m, items);


            return View(vm); 
        }


        [HttpGet]
        public IActionResult AddItem(int id)
        {
            Menu m = context.Menus.Single(c => c.ID == id);

            IEnumerable<Cheese> ch = context.Cheeses.ToList();


            AddMenuItemViewModel vm = new AddMenuItemViewModel(m, ch);

            return View(vm); 
        }

        [HttpPost]
        public IActionResult AddItem(AddMenuItemViewModel vm)
        {
            if (ModelState.IsValid)
            {
                IList<CheeseMenu> existingItems = context.CheeseMenus
                    .Where(cm => cm.CheeseID == vm.cheeseID)
                    .Where(cm => cm.MenuID == vm.menuID).ToList();
                
                if (existingItems.Count() == 0)
                {

                    CheeseMenu cm = new CheeseMenu
                    {
                        MenuID = vm.menuID,
                        CheeseID = vm.cheeseID,
                    };
                    context.CheeseMenus.Add(cm);
                    context.SaveChanges();
                }

                return Redirect("/Menu/ViewMenu/" + vm.menuID);
            }

            return View(vm);
        }

    }

}
