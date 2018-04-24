using hunterview.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Experience
    {
        [Key]
        public int ExperienceId { get; set; }
        public int Note { get; set; }
        public DateTime AddDate { get; set; }
        public bool Valid { get; set; }
        [ForeignKey("SpecialityId")]
        public Speciality Speciality { get; set; }
        [ForeignKey("userId")]
        public ApplicationUser Jobseeker { get; set; }

        public int SpecialityId { get; set; }
        public string userId { get; set; }

    }
}
