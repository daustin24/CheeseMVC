using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CheeseMVC.Models.ViewModels
{
    public class AddMenuItemViewModel
    {
        public int cheeseID { get; set; }
        public int menuID { get; set; }

        public Menu Menu { get; set; }
        public List<SelectListItem> Cheeses { get; set; }



        public AddMenuItemViewModel(Menu m, IEnumerable<Cheese> ch)
        {
            Menu = m; 
            Cheeses = new List<SelectListItem>();

            foreach (Cheese cheese in ch)
            {
                Cheeses.Add(new SelectListItem
                {
                    Value = cheese.ID.ToString(),
                    Text = cheese.Name
                });
            }

        }

        public AddMenuItemViewModel()
        {

        }


    }
}
