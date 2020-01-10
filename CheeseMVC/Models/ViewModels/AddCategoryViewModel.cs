using System;
using System.ComponentModel.DataAnnotations;

namespace CheeseMVC.Models.ViewModels
{
    public class AddCategoryViewModel
    {
        [Required]
        [Display(Name = "Category Name")] 
        public string Name { get; set; }


        public AddCategoryViewModel()
        {
        }
    }
}
