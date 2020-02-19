using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class RepairOrder
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        [Display(Name = "Time Required")]
        public double TimeRequired { get; set; }
        [Display(Name = "Date and time of Repair")]
        public string RepairDate { get; set; }
        
        [Display(Name = "Mechanic")]
        public string Technician { get; set; }
        [Display(Name = "Customer")]
        public string CustomerOnOrder { get; set; }
        [Display(Name = "Before Picture")]
        public string BeforePicture { get; set; }
        [Display(Name ="After Picture")]
        public string AfterPicture { get; set; }
        
        [Display(Name = "Vehicle ID")]
        public int VehicleNumber { get; set; }
        [Display(Name = "List of parts")]
        public string  PartsList { get; set; }
        [Display(Name = "Total parts cost")]
        public string PartsCost { get; set; }
        [Display(Name = "Hours of Labor")]
        public string LaborTotal { get; set; }
        [Display(Name = "Total Labor cost")]
        public string LaborCost { get; set; }
        [Display(Name = "Vehicle problems")]
        public string StatedIssues { get; set; }
        public bool Complete { get; set; }
        [Display(Name = "Current update on repair")]
        public string Status { get; set; }



    }
}