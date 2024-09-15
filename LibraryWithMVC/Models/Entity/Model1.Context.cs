﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DB_LibraryWithMVCEntities : DbContext
    {
        public DB_LibraryWithMVCEntities()
            : base("name=DB_LibraryWithMVCEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tbl_author> tbl_author { get; set; }
        public virtual DbSet<tbl_book> tbl_book { get; set; }
        public virtual DbSet<tbl_category> tbl_category { get; set; }
        public virtual DbSet<tbl_member> tbl_member { get; set; }
        public virtual DbSet<tbl_movement> tbl_movement { get; set; }
        public virtual DbSet<tbl_punishment> tbl_punishment { get; set; }
        public virtual DbSet<tbl_safe> tbl_safe { get; set; }
        public virtual DbSet<tbl_staff> tbl_staff { get; set; }
        public virtual DbSet<tbl_about> tbl_about { get; set; }
        public virtual DbSet<tbl_communication> tbl_communication { get; set; }
        public virtual DbSet<tbl_message> tbl_message { get; set; }
        public virtual DbSet<tbl_announcement> tbl_announcement { get; set; }
        public virtual DbSet<tbl_admin> tbl_admin { get; set; }
    
        public virtual ObjectResult<GetTopAuthorByBookCount_Result> GetTopAuthorByBookCount()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetTopAuthorByBookCount_Result>("GetTopAuthorByBookCount");
        }
    }
}
