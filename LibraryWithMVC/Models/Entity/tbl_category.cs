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
    using System.ComponentModel.DataAnnotations;

    public partial class tbl_category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_category()
        {
            this.tbl_book = new HashSet<tbl_book>();
        }
    
        public byte ctg_id { get; set; }
        [Required(ErrorMessage = "Kategori Ad� Alan� Zorunludur!")]
        [StringLength(20, ErrorMessage = "Kategori Ad� Alan� En Fazla 20 Karakter Alabilir!")]
        public string ctg_name { get; set; }
        public Nullable<bool> ctg_status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_book> tbl_book { get; set; }
    }
}
