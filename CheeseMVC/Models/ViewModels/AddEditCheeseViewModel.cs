using System;
using System.ComponentModel.DataAnnotations;


namespace CheeseMVC.Models.ViewModels
{
    public class AddEditCheeseViewModel : AddCheeseViewModel
    {
        
        public int CheeseId { get; set; }



        public AddEditCheeseViewModel()
        {

        }



        public AddEditCheeseViewModel(Cheese ch)
        {
            // Use the cheese object to initalize 
            CheeseId = ch.CheeseId;
            Name = ch.Name;
            Description = ch.Description;
            Type = ch.Type;
            Rating = ch.Rating;
        }
    }
}
