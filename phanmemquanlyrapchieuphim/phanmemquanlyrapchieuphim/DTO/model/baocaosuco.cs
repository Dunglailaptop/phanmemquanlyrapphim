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
    
    public partial class baocaosuco
    {
        public int id { get; set; }
        public string tieude { get; set; }
        public string moto { get; set; }
        public byte[] picture { get; set; }
        public Nullable<int> Maloai { get; set; }
        public string Manhanvien { get; set; }
    
        public virtual nhanvien nhanvien { get; set; }
        public virtual loaihonghoc loaihonghoc { get; set; }
    }
}
