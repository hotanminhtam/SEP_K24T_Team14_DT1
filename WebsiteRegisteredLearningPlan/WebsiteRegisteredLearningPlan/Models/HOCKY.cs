//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebsiteRegisteredLearningPlan.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HOCKY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOCKY()
        {
            this.CTDTs = new HashSet<CTDT>();
        }
    
        public string tenhk { get; set; }
        public int mahk { get; set; }
        public Nullable<System.DateTime> ngaybd { get; set; }
        public Nullable<System.DateTime> ngaykt { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDT> CTDTs { get; set; }
    }
}
