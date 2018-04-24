using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hunterview.Models
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        public string IdUser { get; set; }
      
        public int IdResponse { get; set; }
        [ForeignKey("IdUser")]
        public ApplicationUser User { get; set; }
        [ForeignKey("IdResponse")]
        public Response Response { get; set; }
    }
}
