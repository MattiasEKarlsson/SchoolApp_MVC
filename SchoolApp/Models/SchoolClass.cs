using SchoolApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApp.Models
{
    public class SchoolClass
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string ClassName { get; set; }

        [DisplayName("Teacher Id")]
        public string TeacherId { get; set; }

        [ForeignKey("TeacherId")]
        public virtual ApplicationUser Teacher { get; set; }
    }
}
