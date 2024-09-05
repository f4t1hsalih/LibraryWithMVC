using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryWithMVC.Models.Entity;

namespace LibraryWithMVC.Models.MyClasses
{
    public class Class1
    {
        public IEnumerable<tbl_book> bookEnumerable { get; set; }
        public IEnumerable<tbl_about> aboutEnumerable { get; set; }
    }
}