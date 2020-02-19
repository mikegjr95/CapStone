using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class Shop
    {
        public int ShopId { get; set; }
        [Display(Name = "Shop Name")]
        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string ShopName { get; set; }


        [Display(Name = "Porsche Street")]
        public string StreetP { get; set; }
        [Display(Name = "McLaren Street")]
        public string StreetMc { get; set; }
        [Display(Name = "Masarati Street")]
        public string StreetM { get; set; }
        [Display(Name = " Porsche Zip")]
        public int ZipP { get; set; }
        [Display(Name = "Masarati Zip")]
        public int ZipM { get; set; }
        [Display(Name = "McLaren Zip")]
        public int ZipMc { get; set; }
        [Display(Name = "Masarati State")]
        public string StateM { get; set; }
        [Display(Name = "Porsche State")]
        public string StateP { get; set; }
        [Display(Name = "McLaren State")]
        public string StateMc { get; set; }


    }
}