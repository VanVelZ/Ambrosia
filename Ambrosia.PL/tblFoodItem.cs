//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ambrosia.PL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblFoodItem
    {
        public System.Guid Id { get; set; }
        public int FDCId { get; set; }
        public System.Guid MealId { get; set; }
        public int Quantity { get; set; }
    
        public virtual tblMeal tblMeal { get; set; }
    }
}
