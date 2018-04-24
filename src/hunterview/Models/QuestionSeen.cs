using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hunterview.Models
{
    public class QuestionSeen
    {
        [Key]
        public int QuestionSeenId { get; set; }
        public int QuestionId { get; set; }
        public string userId { get; set; }
        [ForeignKey("QuestionId")]
        public Question Question { get; set; }
        [ForeignKey("userId")]
        public ApplicationUser user { get; set; }
    }
}
