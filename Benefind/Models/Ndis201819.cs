using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Benefind.Models
{
    public partial class Ndis201819
    {
        [Display(Name = "Registration Group")]
        public string RegistrationGroup { get; set; }
        [Display(Name = "Support Item Number")]
        public string SupportItemNumber { get; set; }
        [Display(Name = "Support Item")]
        public string SupportItem { get; set; }
        [Display(Name = "Support Item Description")]
        public string SupportItemDescription { get; set; }
        [Display(Name = "Unit Of Measure")]
        public string UnitOfMeasure { get; set; }
        [Display(Name = "Quote")]
        public string Quote { get; set; }
        [Display(Name = "Price Limit")]
        public double? PriceLimit { get; set; }
        [Display(Name = "Price Control")]
        public string PriceControl { get; set; }
        [Display(Name = "Support Categories")]
        public string SupportCategories { get; set; }
        [Display(Name = "Support Category Number")]
        public string SupportCategoryNumber { get; set; }
    }
}
