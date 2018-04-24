using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hunterview.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Employers { get; set; }
        public string WebSite{ get; set; }
        public string PhoneNumber { get; set; }
        public string Image { get; set; }
        public string CoverImage { get; set; }
        public string ShortDescription { get; set; }
        public string Detail { get; set; }
        public string HeadLine { get; set; }
        [JsonIgnore]
        public ICollection<Job> Jobs { get; set; }
        [JsonIgnore]
        public ICollection<Favorite> Favorites { get; set; }

    }
}
