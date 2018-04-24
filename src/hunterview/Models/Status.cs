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
    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }
        public DateTime AddDate { get; set; }
        public bool Valid { get; set; }
		[JsonIgnore]
        public ICollection<Comment> Commentss { get; set; }
        [ForeignKey("testId")]
        public ApplicationUser JobSeeker { get; set; }
        public string testId { get; set; }

        [DataType(DataType.ImageUrl), Display(Name = "Image")]
        public string ImageUrl { get; set; }



    }
}
