//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Languages.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class langfam_lang_link
    {
        public int id { get; set; }
        public int langfam_id { get; set; }
        public int lang_id { get; set; }
    
        public virtual language language { get; set; }
        public virtual language_family language_family { get; set; }
    }
}
