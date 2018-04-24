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
    public class LanguageUser
    {
        [Key]
        public int LanguageUserid { get; set; }
        public Language Language1 { get; set; }
        
        public string idUser { get; set; }
        [ForeignKey("idUser")]
        [JsonIgnore]
        public ApplicationUser User { get; set; }
    }

    public enum Language { Francais,English,Spanish,Russian,Italian}
}
