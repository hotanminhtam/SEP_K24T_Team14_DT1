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
    
    public partial class CTDT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CTDT()
        {
            this.KETQUADANGKies = new HashSet<KETQUADANGKY>();
        }
    
        public int id { get; set; }
        public string tenhp { get; set; }
        public string mahp { get; set; }
        public Nullable<int> tinchi { get; set; }
        public Nullable<int> hocky { get; set; }
    
        public virtual HOCKY HOCKY1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KETQUADANGKY> KETQUADANGKies { get; set; }
    }
}
