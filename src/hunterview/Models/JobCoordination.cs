using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hunterview.Models
{
    public class JobCoordination
    {
        public int JobCoordinationId { get; set; }
        public string idUser { get; set; }
        public int JobId { get; set; }
         [ForeignKey("idUser")]
        public ApplicationUser Jobseeker { get; set; }
        [ForeignKey("JobId")]
        public Job Job { get; set; }
        public DateTime Adddate { get; set; }
        public bool Approved { get; set; }

    }
}
