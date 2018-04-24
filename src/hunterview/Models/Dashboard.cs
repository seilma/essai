using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Dashboard
    {
        [Key]
        public int DashboardId { get; set; }
        public String MsgOfDay { get; set; }

        [DataType(DataType.ImageUrl), Display(Name = "Image")]
        public string ImageUrl
        {
            get; set;

        }
    }
}
