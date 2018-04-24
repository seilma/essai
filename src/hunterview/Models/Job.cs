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
  public  class Job
    {
        [Key]
        public int JobId { get; set; }
       
        public Sector Sector { get; set; }
        public String Title { get; set; }
       
        public DateTime AddDate { get; set; }
        
        public DateTime ExprerationDate { get; set; }
        public String Description { get; set; }
        public int Expertise { get; set; }
       
        public int  SpecilityId { get; set; }
        [ForeignKey("SpecilityId")]
        
        public Speciality Speciality { get; set; }
        [JsonIgnore]
        public State State { get; set; }
       
        public DateTime StartDate { get; set; }
        public double Salary { get; set; }
        public int NbrJaime { get; set; }
        public ICollection<JobCoordination> JobCoordinations { get; set; }
        public int nbrjaimepas { get; set; }
        public bool Valid { get; set; }
        [ForeignKey("testId")]
      
        public ApplicationUser Headhunter { get; set; }
        [JsonIgnore]
        public ICollection<JaimeJob> JaimeJobs { get; set; }
        
        public string testId { get; set; }
        [JsonIgnore]
        public ICollection<CommentaireJob> Commentaires { get; set; }

        public String Position { get; set; }
        public String Entreprise { get; set; }
        public String Address { get; set; }
        public Degree Degree { get; set; }
        public string Details { get; set; }
        public JobType Type { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        public int WorkHours { get; set; }

        public int CompanyId { get; set; }



    }
    public enum State {

        Valide, Expired, Booked 
    }
    public enum JobType
    {
        FullTime,Training,Freelance

    }
    public enum Degree
    {
        bachelor, Master , Doctoral , Licence
    }


}
