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
    
    public partial class Fish
    {
        public int Id { get; set; }
        public int FishTypeId { get; set; }
        public int Length { get; set; }
        public byte[] Image { get; set; }
        public string LureType { get; set; }
        public byte[] ImageLure { get; set; }
        public string Comment { get; set; }
        public System.DateTime TimeDate { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Nullable<int> Weight { get; set; }
    
        public virtual FishType FishType { get; set; }
    }
}
