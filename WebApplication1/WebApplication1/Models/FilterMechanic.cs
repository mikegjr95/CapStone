using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class FilterMechanic
    {
        public List<Mechanic> mechanics { get; set; }
        
        [Display(Name = "Search by Zip")]
        public SelectList SearchByZip { get; set; }
        
        public string Zip { get; set; }

        [Display(Name ="Shop")]
        public string SelectedShop { get; set; }

        [Display(Name = "All Shops")]
        public SelectList ListOfShops { get; set; }


    }
}