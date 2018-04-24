using hunterview.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class JaimeJob
    {
        public int Id { get; set; }
        public bool Yes { get; set; }
        public DateTime AddDate { get; set; }
        [ForeignKey("idUser")]
        public ApplicationUser User { get; set; }
        [ForeignKey("idJob")]
        public Job Job { get; set; }
        public int idJob { get; set; }
        public string idUser { get; set; }

    }
}
