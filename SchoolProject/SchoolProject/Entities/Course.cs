namespace SchoolProject.Entities
{
    using SchoolProject.Services;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("courses")]
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            assignments = new HashSet<Assignment>();
            students = new HashSet<Student>();
            trainers = new HashSet<Trainer>();
        }

        public Course(int id, string title, string stream, string type, DateTime start_Date, DateTime end_Date)
        {
            Id = id;
            Title = title;
            Stream = stream;
            Type = type;
            Start_Date = start_Date;
            End_Date = end_Date;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string Stream { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        public DateTime Start_Date { get; set; }

        private DateTime end_Date;
        public DateTime End_Date
        {
            get
            {
                return end_Date;
            }
            set

            {
                do
                {
                    if (Start_Date< value)
                    {
                        end_Date = value;
                        break;

                    }
                    Console.WriteLine("You cant put an end date that is before the starting date, try again");
                    value = ValidationInputs.GetDate("end date of the course");
                } while (true);

            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Assignment> assignments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> students { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trainer> trainers { get; set; }

        public override string ToString()
        {
            return ($"Id:{Id}\t\nTitle: {Title}\t\nStream: {Stream}\t\nType: {Type}\t\nStart_Date: {Start_Date}\t\nStart_Date: {Start_Date}\t\nEnd_Date: {End_Date}");
        }

        
    }
}
