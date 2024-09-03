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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class tbl_member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_member()
        {
            this.tbl_movement = new HashSet<tbl_movement>();
            this.tbl_punishment = new HashSet<tbl_punishment>();
        }

        public int mmb_id { get; set; }
        [Required(ErrorMessage ="�sim Alan� Bo� B�rak�lamaz!")]
        [StringLength(20, ErrorMessage = "Ad 20 karekteri ge�emez!")]
        public string mmb_name { get; set; }
        [StringLength(20, ErrorMessage = "Soyad 20 karekteri ge�emez!")]
        public string mmb_surname { get; set; }
        [EmailAddress]
        public string mmb_email { get; set; }
        [StringLength(20, ErrorMessage = "Kullan�c� Ad� 20 karekteri ge�emez!")]
        public string mmb_username { get; set; }
        [PasswordPropertyText]
        [StringLength(20, ErrorMessage = "�ifre 20 karekteri ge�emez!")]
        public string mmb_password { get; set; }
        public string mmb_photo { get; set; }
        [StringLength(20, ErrorMessage = "Telefon numaras� 20 karekteri ge�emez!")]
        public string mmb_tel { get; set; }
        [StringLength(20, ErrorMessage = "Okul �smi 100 karekteri ge�emez!")]
        public string mmb_school { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_movement> tbl_movement { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_punishment> tbl_punishment { get; set; }
    }
}
