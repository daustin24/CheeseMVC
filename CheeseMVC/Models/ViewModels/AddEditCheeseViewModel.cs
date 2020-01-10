using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CheeseMVC.Models.ViewModels
{
    public class AddEditCheeseViewModel : AddCheeseViewModel
    {
        
        public int CheeseId { get; set; }




        public AddEditCheeseViewModel()
        {

        }



        public AddEditCheeseViewModel(Cheese ch, IEnumerable<CheeseCategory> categories) : base(categories)
        {
            // Use the cheese object to initalize 
            CheeseId = ch.ID;
            Name = ch.Name;
            Description = ch.Description;
            CategoryID = ch.CategoryID;
            Rating = ch.Rating;
        }
    }
}
