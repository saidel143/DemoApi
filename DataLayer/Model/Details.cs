//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Portales.Dal.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Details
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int BillId { get; set; }
        public int ProductId { get; set; }
    
        public virtual Bill Bill { get; set; }
        public virtual Product Product { get; set; }
    }
}