//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TLU.Blog.Models.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rule
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Content { get; set; }
        public string Action { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}