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

    public partial class language
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public language()
        {
            this.country_lang_link = new HashSet<country_lang_link>();
            this.langfam_lang_link = new HashSet<langfam_lang_link>();
        }
    
        public int id { get; set; }
        [StringLength(50)]
        [Required()]
        public string name { get; set; }
        [IsYorN()]
        [StringLength(1)]
        [Required()]
        public string agglutinative { get; set; }
        [Required()]
        public int number_of_tenses { get; set; }
        [Required()]
        public int no_of_noun_declension_cases { get; set; }
        [StringLength(20)]
        [Required()]
        public string difficulty { get; set; }
        [Required()]
        public int number_of_speakers { get; set; }
        [Required()]
        public int rank_by_no_speakers { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<country_lang_link> country_lang_link { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<langfam_lang_link> langfam_lang_link { get; set; }
    }
}
