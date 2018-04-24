using hunterview.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Message
    {
        public int MessageId { get; set; }
        public String Object { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }
        public DateTime SendDate { get; set; }
        public bool Seen { get; set; }
        [ForeignKey("Sender_Id")]
        public ApplicationUser Sender { get; set; }
        public string Sender_Id { get; set; }
        [ForeignKey("Receiver_Id")]
        public ApplicationUser Receiver { get; set; }
        public string Receiver_Id { get; set; }
        public bool DeletedS { get; set; }
        public bool DeletedR { get; set; }
    }
}
