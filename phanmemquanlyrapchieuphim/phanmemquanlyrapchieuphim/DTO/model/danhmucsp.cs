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
    
    public partial class danhmucsp
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public danhmucsp()
        {
            this.sanphams = new HashSet<sanpham>();
        }
    
        public int Madm { get; set; }
        public string tendanhmuc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sanpham> sanphams { get; set; }
    }
}
