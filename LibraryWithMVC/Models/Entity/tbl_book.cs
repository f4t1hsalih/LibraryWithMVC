//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryWithMVC.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_book()
        {
            this.tbl_movement = new HashSet<tbl_movement>();
        }
    
        public int bk_id { get; set; }
        public string bk_name { get; set; }
        public Nullable<byte> bk_ctg { get; set; }
        public Nullable<int> bk_ath { get; set; }
        public string bk_year_of_publication { get; set; }
        public string bk_publishing_house { get; set; }
        public string bk_page { get; set; }
        public Nullable<bool> bk_status { get; set; }
    
        public virtual tbl_author tbl_author { get; set; }
        public virtual tbl_category tbl_category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_movement> tbl_movement { get; set; }
    }
}
