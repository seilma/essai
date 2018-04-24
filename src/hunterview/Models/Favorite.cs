using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hunterview.Models
{
    public class Favorite
    {[Key]
        public int FavoriteId { get; set; }
        public int CompanyId { get; set; }
        public string UserId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser   User { get; set; }
    }
}
