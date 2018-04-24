using hunterview.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class WorkExperience

    {
        [Key]
        public int WorkExperienceId { get; set; }
        public string Entreprise { get; set; }
        public string Position { get; set; }
        public int Durée { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string photo { get; set; }
        public string idUser { get; set; }
        [ForeignKey("idUser")]
        [JsonIgnore]
        public ApplicationUser User { get; set; }

    }
}
