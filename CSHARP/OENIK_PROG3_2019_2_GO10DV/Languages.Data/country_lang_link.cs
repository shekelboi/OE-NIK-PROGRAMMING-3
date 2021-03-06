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
    using System.ComponentModel.DataAnnotations;
    
    /// <summary>
    /// Country - language link.
    /// </summary>
    public partial class country_lang_link
    {
        /// <summary>
        /// Id of country_lang_link.
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Country id of country_lang_link.
        /// </summary>
        [Required()]
        public int country_id { get; set; }
        /// <summary>
        /// Language id of country_lang_link.
        /// </summary>
        [Required()]
        public int lang_id { get; set; }
    
        /// <summary>
        /// Country table.
        /// </summary>
        public virtual country country { get; set; }
        /// <summary>
        /// Language table.
        /// </summary>
        public virtual language language { get; set; }
    }
}
