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
    
    public partial class CHITIET_PHIEUDATSAN
    {
        public int MASAN { get; set; }
        public int MAPDS { get; set; }
        public Nullable<int> MAKHUNGGIO { get; set; }
        public Nullable<int> MADICHVU { get; set; }
        public int MAPTT { get; set; }
    
        public virtual DICHVU DICHVU { get; set; }
        public virtual GIO GIO { get; set; }
        public virtual PHIEUDATSAN PHIEUDATSAN { get; set; }
        public virtual PHIEUTHANHTOAN PHIEUTHANHTOAN { get; set; }
        public virtual SAN SAN { get; set; }
    }
}
