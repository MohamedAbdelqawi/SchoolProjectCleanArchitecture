using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class StudentSubject
    {

        [Key]

        public int StudID { get; set; }
        [Key]

        public int SubID { get; set; }
        [ForeignKey("StudID")]
        [InverseProperty("StudentSubjects")]
        public virtual Student? Student { get; set; }
        [ForeignKey("SubID")]
        [InverseProperty("StudentsSubjects")]
        public virtual Subjects? Subject { get; set; }
    }

}
