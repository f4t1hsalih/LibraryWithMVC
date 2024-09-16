using LibraryWithMVC.Models.Entity;
using System.Collections.Generic;

namespace LibraryWithMVC.Models.MyClasses
{
    public class Class1
    {
        public IEnumerable<tbl_book> bookEnumerable { get; set; }
        public IEnumerable<tbl_about> aboutEnumerable { get; set; }
    }
}