//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Oil2UAdmin
{
    using System;
    using System.Collections.Generic;
    
    public partial class Maintenance
    {
        public int MaintenanceId { get; set; }
        public System.DateTime BookedDate { get; set; }
        public string UploadedImage { get; set; }
        public string Comment { get; set; }
        public int UserId { get; set; }
        public string ReferenceEmail { get; set; }
        public string ReferenceAddress { get; set; }
        public string ReferencePhoneNo { get; set; }
    
        public virtual User User { get; set; }
    }
}