//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace phanmemquanlyrapchieuphim.DTO.model
{
    using System;
    using System.Collections.Generic;
    
    public partial class vexem
    {
        public int Mave { get; set; }
        public int Maghe { get; set; }
        public int Machieu { get; set; }
        public string Mahoadon { get; set; }
        public Nullable<decimal> Price { get; set; }
    
        public virtual ghe ghe { get; set; }
        public virtual hoadon hoadon { get; set; }
        public virtual suatchieu suatchieu { get; set; }
    }
}