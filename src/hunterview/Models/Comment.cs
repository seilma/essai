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
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public String Content { get; set; }
        public DateTime AddDate { get; set; }
        public bool Valid { get; set; }
        public int rate { get; set; }
        [ForeignKey("StatusId")]
        public Status Status { get; set; }
        public int StatusId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public int like { get; set; }
        public int dislike { get; set; }
		[JsonIgnore]
        public ICollection<LikeComments> LikeComments { get; set; }

    }
}
