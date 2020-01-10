using System;
using System.Collections.Generic;

namespace CheeseMVC.Models.ViewModels
{
    public class ViewMenuViewModel
    {
        public Menu Menu { get; set; }
        public IList<CheeseMenu> Items { get; set; }

        public ViewMenuViewModel(Menu m, IList<CheeseMenu> i)
        {
            Items = i;
            Menu = m;
        }


        public ViewMenuViewModel()
        {
        }



    }
}
