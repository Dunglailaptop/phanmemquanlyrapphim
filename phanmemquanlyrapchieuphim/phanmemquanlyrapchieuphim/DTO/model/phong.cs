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
    
    public partial class phong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public phong()
        {
            this.ghes = new HashSet<ghe>();
            this.phanloaighebyphongs = new HashSet<phanloaighebyphong>();
            this.suatchieux = new HashSet<suatchieu>();
        }
    
        public int Maphong { get; set; }
        public Nullable<int> Tongsoghe { get; set; }
        public string tenphong { get; set; }
        public Nullable<int> gheofday { get; set; }
        public Nullable<int> active { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ghe> ghes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<phanloaighebyphong> phanloaighebyphongs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<suatchieu> suatchieux { get; set; }
    }
}