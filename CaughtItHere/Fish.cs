//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CaughtItHere
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Fish
    {

        public int Id { get; set; }
        [Required]
        public int FishTypeId { get; set; }
        [Required, Range(1, 120)]
        public int Length { get; set; }
        public string Image { get; set; }
        public string LureType { get; set; }
        public string ImageLure { get; set; }
        public string Comment { get; set; }
        [Required, DataType(DataType.Date)]
        public System.DateTime TimeDate { get; set; }
        [Required, Range(-90, 90)]
        public double Latitude { get; set; }
        [Required, Range(-180, 180)]
        public double Longitude { get; set; }
        [Required, Range(0,1000)]
        public int Weight { get; set; }
    
        public virtual FishType FishType { get; set; }
    }
}
