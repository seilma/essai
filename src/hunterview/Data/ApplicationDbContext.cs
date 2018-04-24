using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using hunterview.Models;
using Domain;

namespace hunterview.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<ApplicationUser> AppUSers { get; set; }
       // public DbSet<LanguageUser> AppUSers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            
        }
        public DbSet<Speciality> Speciality { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Response> Response { get; set; }
        public DbSet<CommentaireJob> CommentaireJob { get; set; }
        public DbSet<Experience> Experience { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<JaimeJob> JaimeJob { get; set; }
        public DbSet<LanguageUser> LanguageUser { get; set; }
       
        public DbSet<Message> Message { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<WorkExperience> WorkExperience { get; set; }
        public DbSet<QuestionSeen> QuestionSeen { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<JobCoordination> JobCoordination { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Favorite> Favorite { get; set; }
    }
}
