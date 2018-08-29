using System;
using System.Collections.Generic;

namespace Benefind.Models
{
    public partial class Ndis201819
    {
        public string RegistrationGroup { get; set; }
        public string SupportItemNumber { get; set; }
        public string SupportItem { get; set; }
        public string SupportItemDescription { get; set; }
        public string UnitOfMeasure { get; set; }
        public string Quote { get; set; }
        public double? PriceLimit { get; set; }
        public string PriceControl { get; set; }
        public string SupportCategories { get; set; }
        public string SupportCategoryNumber { get; set; }
    }
}
