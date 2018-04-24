using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hunterview.Models
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public TypeNotif TypeNotif { get; set; }
        public bool Seen { get; set; }
        public DateTime Date { get; set; }
        public int TypeId { get; set; }
        public string Subject { get; set; }
    }

    public enum TypeNotif
    {
        Job,Message,Status,Company
    }
}
