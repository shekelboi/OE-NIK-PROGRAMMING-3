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
    /// Language table.
    /// </summary>
    public partial class language
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="language"/> class.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public language()
        {
            this.country_lang_link = new HashSet<country_lang_link>();
            this.langfam_lang_link = new HashSet<langfam_lang_link>();
        }
    
        /// <summary>
        /// Id of a language.
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Name of a language.
        /// </summary>
        [StringLength(50)]
        [Required()]
        public string name { get; set; }
        /// <summary>
        /// Whether a language is agglutinative.
        /// </summary>
        [IsTorF()]
        [StringLength(1)]
        [Required()]
        public string agglutinative { get; set; }
        /// <summary>
        /// Number of tenses in a language.
        /// </summary>
        [Required()]
        public int number_of_tenses { get; set; }
        /// <summary>
        /// Number of noun declension cases in a language.
        /// </summary>
        [Required()]
        public int no_of_noun_declension_cases { get; set; }
        /// <summary>
        /// Difficulty of a language.
        /// </summary>
        [StringLength(20)]
        [Required()]
        public string difficulty { get; set; }
        /// <summary>
        /// Number of speakers of a language.
        /// </summary>
        [Required()]
        public int number_of_speakers { get; set; }
        /// <summary>
        /// Rank by number of speakers of a language.
        /// </summary>
        [Required()]
        public int rank_by_no_speakers { get; set; }
    
        /// <summary>
        /// Country - language link table.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<country_lang_link> country_lang_link { get; set; }
        /// <summary>
        /// Language family - language link table.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<langfam_lang_link> langfam_lang_link { get; set; }
    }
}
