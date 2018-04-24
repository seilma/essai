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
    public class CommentaireJob
    {       [Key]
        public int CommentaireId { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [ForeignKey("IdUser")]
        [JsonIgnore]
        public ApplicationUser User { get; set; }
        public DateTime AddDate { get; set; }
        public string IdUser { get; set; }
        [ForeignKey("JobId")]
        [JsonIgnore]
        public Job Job { get; set; }
        public int JobId { get; set; }

    }
}
