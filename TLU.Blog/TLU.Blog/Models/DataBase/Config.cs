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
    
    public partial class Config
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Nullable<int> Order { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<byte> LangId { get; set; }
    }
}
