//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAppQuanLyBongDa.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SAN()
        {
            this.CHITIET_PHIEUDATSAN = new HashSet<CHITIET_PHIEUDATSAN>();
            this.TINHTRANGSANs = new HashSet<TINHTRANGSAN>();
        }
    
        public int MASAN { get; set; }
        public string TENSAN { get; set; }
        public string TRANGTHAI { get; set; }
        public int MALOAISAN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIET_PHIEUDATSAN> CHITIET_PHIEUDATSAN { get; set; }
        public virtual LOAISAN LOAISAN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TINHTRANGSAN> TINHTRANGSANs { get; set; }
    }
}
