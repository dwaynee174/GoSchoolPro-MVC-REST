//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GoSchoolProMVC.Models.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class AirportPckUp
    {
        public int FlightNo { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public Nullable<long> Contact { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public string ArrivalAirport { get; set; }
        public string FlightName { get; set; }
        public Nullable<System.DateTime> ArrivalDate { get; set; }
        public Nullable<System.TimeSpan> ArrivalTime { get; set; }
        public Nullable<int> APUserId { get; set; }
    
        public virtual Student Student { get; set; }
    }
}
