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
   public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        public string Content { get; set; }
        [ForeignKey("SpecialityId")]
        public Speciality Speciality { get; set; }
      public  ICollection<QuestionSeen>  QuestionSeens{ get; set; }
    public int SpecialityId { get; set; }
        //public Response Response { get; set; }
        [JsonIgnore]
        public ICollection<Response> Responses { get; set; }
    }

}
