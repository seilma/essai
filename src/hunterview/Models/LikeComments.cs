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
   public  class LikeComments
    {
        [Key]
        public int Id { get; set; }
        public bool Yes { get; set; }
        public DateTime AddDate { get; set; }
        [ForeignKey("idUser")]
        public ApplicationUser User { get; set; }
        public string idUser { get; set; }
        [ForeignKey("CommentId")]
        public Comment Comment { get; set; }
        public int CommentId { get; set; }
    }
}
