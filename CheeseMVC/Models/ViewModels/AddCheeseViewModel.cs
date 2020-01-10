using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using CheeseMVC.Models.ViewModels; 

namespace CheeseMVC.Models.ViewModels
{
    public class AddCheeseViewModel
    {
        [Required]
        [Display(Name = "Cheese Name")] 
        public string Name { get; set; }

        [Required(ErrorMessage = "You must give your cheese a description")] 
        public string Description { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        public List<SelectListItem> Categories { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        
        //public List<SelectListItem> CheeseTypes { get; set; }

        public AddCheeseViewModel(IEnumerable<CheeseCategory> categories)
        {
            Categories = new List<SelectListItem>();

            foreach (CheeseCategory category in categories)
            {
                Categories.Add(new SelectListItem
                {
                    Value = category.ID.ToString(), 
                    Text = category.Name 
                });
            }

            //// HTML <options value="0">Soft</option> 
            //CheeseTypes.Add(new SelectListItem
            //{
            //    Value = ((int)CheeseType.Soft).ToString(),
            //    Text = CheeseType.Soft.ToString()
            //});
            //CheeseTypes.Add(new SelectListItem
            //{
            //    Value = ((int)CheeseType.Hard).ToString(),
            //    Text = CheeseType.Hard.ToString()
            //});
            //CheeseTypes.Add(new SelectListItem
            //{
            //    Value = ((int)CheeseType.Fake).ToString(),
            //    Text = CheeseType.Fake.ToString()
            //});

        }

        public AddCheeseViewModel()
        {

        }


        public Cheese CreateCheese()
        {
            Cheese newCheese = new Cheese
            {
                Name = Name,
                Description = Description,
                CategoryID = CategoryID,
                Rating = Rating
            };

            return newCheese; 
        } 

    }
}
