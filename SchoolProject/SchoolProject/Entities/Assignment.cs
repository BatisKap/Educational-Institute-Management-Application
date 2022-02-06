namespace SchoolProject.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Assignment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Assignment()
        {
            courses = new HashSet<Course>();
        }

        public Assignment(int id, string title, string description, DateTime subDateTime, int oralMark, int totalMark)
        {
            Id = id;
            Title = title;
            Description = description;
            SubDateTime = subDateTime;
            OralMark = oralMark;
            TotalMark = totalMark;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public DateTime SubDateTime { get; set; }

        public int OralMark { get; set; }

        public int TotalMark { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course> courses { get; set; }


        public override string ToString()
        {
            return ($"Id:{Id}\t\nTitle: {Title}\t\nDescription: {Description}\t\nSubDateTime: {SubDateTime}\t\nOralMark: {OralMark}\t\nTotalMark: {TotalMark}");
        }
    }
}
