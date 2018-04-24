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
    public class UserHobies
    {
        [Key]

        public int UserHobiesid { get; set; }
        public string Label { get; set; }
        public string idUser { get; set; }
        [ForeignKey("idUser")]
        [JsonIgnore]
        public ApplicationUser User { get; set; }
    }

    
}
