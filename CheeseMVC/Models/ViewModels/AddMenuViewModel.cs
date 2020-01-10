using System;
using System.ComponentModel.DataAnnotations;

namespace CheeseMVC.Models.ViewModels
{
    public class AddMenuViewModel
    {
        [Required]
        [Display(Name = "Menu Name")]
        public string Name { get; set; }


        public AddMenuViewModel()
        {
        }
    }
}
