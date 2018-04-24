using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hunterview.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public String Password { get; set; }
        public DateTime LastLogin { get; set; }
        public bool Locked { get; set; }
        public bool Expied { get; set; }
        public String LastName { get; set; }
        public String FirstName { get; set; }
        public DateTime Birthday { get; set; }
        public String ProffesinolaStatus { get; set; }
        public Country Country { get; set; }
        public Degree Degree { get; set; }
        public Gender gender { get; set; }
        public String Number { get; set; }
        public Sector Sector { get; set; }
        public int Age { get; set; }
        public string Token { get; set; }
        public Tenant Tenant { get; set; }
        public string profilePhoto { get; set; }
       // public ICollection<ApplicationUser> Friends { get; set; }
        public ICollection<Status> Status { get; set; }
        public ICollection<Comment> Comments { get; set; }
      //  public ICollection<Message> Messages { get; set; }
        public ICollection<CommentaireJob> CommentairesJobs { get; set; }
        public ICollection<WorkExperience> WorkExperiences { get; set; }
        public ICollection<LanguageUser> LanguageUsers { get; set; }
        public ICollection<UserHobies> UserHobies { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ICollection<QuestionSeen> QuestionSeens { get; set; }
        public ICollection<JobCoordination> JobCoordinations { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<Favorite> Favorites { get; set; }

        public string photoCouverture { get; set; }
       
        public string Description { get; set; }
        public Role Role { get; set; }
        public int rate { get; set; }
        [ForeignKey("testId")]
        public ApplicationUser LastHeadHunter { get; set; }
        public string testId { get; set; }

    }
    public enum Role
    {
        Admin,JobSeeker,HeadHunter


    }
   
    public enum Country
    {
        France,Tunisia,UnitedStates,Germany,Poland,Cameroon,Espagne,Togo,Algeria,Maroc

    }
    public enum Gender
    {
        Male,Female
    }
    public enum Tenant
    {
        Google,Facebook,Microsoft,Ibm

    }
    public enum Degree
    {
        bachelor, Master, Doctoral, Licence
    } 
}
