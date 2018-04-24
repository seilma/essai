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
    public class Response
    {
        [Key]
        public int ResponseId { get; set; }
        public String Content { get; set; }
        public bool Valide { get; set; }
        [ForeignKey("QuestionId")]
        public Question Question { get; set; }
        public int QuestionId { get; set; }
        [JsonIgnore]
        public ICollection<Answer> Answers { get; set; }

    }
}
