using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using hunterview.Data;

namespace hunterview.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddDate");

                    b.Property<string>("Content");

                    b.Property<int>("StatusId");

                    b.Property<string>("UserId");

                    b.Property<bool>("Valid");

                    b.Property<int>("dislike");

                    b.Property<int>("like");

                    b.Property<int>("rate");

                    b.HasKey("CommentId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("Domain.CommentaireJob", b =>
                {
                    b.Property<int>("CommentaireId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddDate");

                    b.Property<string>("Description");

                    b.Property<string>("IdUser");

                    b.Property<int>("JobId");

                    b.HasKey("CommentaireId");

                    b.HasIndex("IdUser");

                    b.HasIndex("JobId");

                    b.ToTable("CommentaireJob");
                });

            modelBuilder.Entity("Domain.Experience", b =>
                {
                    b.Property<int>("ExperienceId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddDate");

                    b.Property<int>("Note");

                    b.Property<int>("SpecialityId");

                    b.Property<bool>("Valid");

                    b.Property<string>("userId");

                    b.HasKey("ExperienceId");

                    b.HasIndex("SpecialityId");

                    b.HasIndex("userId");

                    b.ToTable("Experience");
                });

            modelBuilder.Entity("Domain.JaimeJob", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddDate");

                    b.Property<bool>("Yes");

                    b.Property<int>("idJob");

                    b.Property<string>("idUser");

                    b.HasKey("Id");

                    b.HasIndex("idJob");

                    b.HasIndex("idUser");

                    b.ToTable("JaimeJob");
                });

            modelBuilder.Entity("Domain.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddDate");

                    b.Property<string>("Address");

                    b.Property<int>("CompanyId");

                    b.Property<int>("Degree");

                    b.Property<string>("Description");

                    b.Property<string>("Details");

                    b.Property<string>("Entreprise");

                    b.Property<int>("Expertise");

                    b.Property<DateTime>("ExprerationDate");

                    b.Property<int>("NbrJaime");

                    b.Property<string>("Position");

                    b.Property<double>("Salary");

                    b.Property<int>("Sector");

                    b.Property<int>("SpecilityId");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("State");

                    b.Property<string>("Title");

                    b.Property<int>("Type");

                    b.Property<bool>("Valid");

                    b.Property<int>("WorkHours");

                    b.Property<int>("nbrjaimepas");

                    b.Property<string>("testId");

                    b.HasKey("JobId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("SpecilityId");

                    b.HasIndex("testId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("Domain.LanguageUser", b =>
                {
                    b.Property<int>("LanguageUserid")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Language1");

                    b.Property<string>("idUser");

                    b.HasKey("LanguageUserid");

                    b.HasIndex("idUser");

                    b.ToTable("LanguageUser");
                });

            modelBuilder.Entity("Domain.LikeComments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddDate");

                    b.Property<int>("CommentId");

                    b.Property<bool>("Yes");

                    b.Property<string>("idUser");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("idUser");

                    b.ToTable("LikeComments");
                });

            modelBuilder.Entity("Domain.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<bool>("DeletedR");

                    b.Property<bool>("DeletedS");

                    b.Property<string>("Object");

                    b.Property<string>("Receiver_Id");

                    b.Property<bool>("Seen");

                    b.Property<DateTime>("SendDate");

                    b.Property<string>("Sender_Id");

                    b.Property<string>("Title");

                    b.HasKey("MessageId");

                    b.HasIndex("Receiver_Id");

                    b.HasIndex("Sender_Id");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("Domain.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<int>("SpecialityId");

                    b.HasKey("QuestionId");

                    b.HasIndex("SpecialityId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("Domain.Response", b =>
                {
                    b.Property<int>("ResponseId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<int>("QuestionId");

                    b.Property<bool>("Valide");

                    b.HasKey("ResponseId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Response");
                });

            modelBuilder.Entity("Domain.Speciality", b =>
                {
                    b.Property<int>("SpecialityId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("Sector");

                    b.Property<string>("Title");

                    b.HasKey("SpecialityId");

                    b.ToTable("Speciality");
                });

            modelBuilder.Entity("Domain.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddDate");

                    b.Property<string>("Content");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Title");

                    b.Property<bool>("Valid");

                    b.Property<string>("testId");

                    b.HasKey("StatusId");

                    b.HasIndex("testId");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Domain.UserHobies", b =>
                {
                    b.Property<int>("UserHobiesid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Label");

                    b.Property<string>("idUser");

                    b.HasKey("UserHobiesid");

                    b.HasIndex("idUser");

                    b.ToTable("UserHobies");
                });

            modelBuilder.Entity("Domain.WorkExperience", b =>
                {
                    b.Property<int>("WorkExperienceId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Durée");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Entreprise");

                    b.Property<string>("Position");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("idUser");

                    b.Property<string>("photo");

                    b.HasKey("WorkExperienceId");

                    b.HasIndex("idUser");

                    b.ToTable("WorkExperience");
                });

            modelBuilder.Entity("hunterview.Models.Answer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdResponse");

                    b.Property<string>("IdUser");

                    b.HasKey("AnswerId");

                    b.HasIndex("IdResponse");

                    b.HasIndex("IdUser");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("hunterview.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<int>("Age");

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<int>("Country");

                    b.Property<int>("Degree");

                    b.Property<string>("Description");

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("Expied");

                    b.Property<string>("FirstName");

                    b.Property<DateTime>("LastLogin");

                    b.Property<string>("LastName");

                    b.Property<bool>("Locked");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("Number");

                    b.Property<string>("Password");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("ProffesinolaStatus");

                    b.Property<int>("Role");

                    b.Property<int>("Sector");

                    b.Property<string>("SecurityStamp");

                    b.Property<int>("Tenant");

                    b.Property<string>("Token");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<int>("gender");

                    b.Property<string>("photoCouverture");

                    b.Property<string>("profilePhoto");

                    b.Property<int>("rate");

                    b.Property<string>("testId");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.HasIndex("testId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("hunterview.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CoverImage");

                    b.Property<string>("Detail");

                    b.Property<string>("Employers");

                    b.Property<string>("HeadLine");

                    b.Property<string>("Image");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("ShortDescription");

                    b.Property<string>("WebSite");

                    b.HasKey("CompanyId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("hunterview.Models.Favorite", b =>
                {
                    b.Property<int>("FavoriteId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompanyId");

                    b.Property<string>("UserId");

                    b.HasKey("FavoriteId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("UserId");

                    b.ToTable("Favorite");
                });

            modelBuilder.Entity("hunterview.Models.JobCoordination", b =>
                {
                    b.Property<int>("JobCoordinationId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Adddate");

                    b.Property<bool>("Approved");

                    b.Property<int>("JobId");

                    b.Property<string>("idUser");

                    b.HasKey("JobCoordinationId");

                    b.HasIndex("JobId");

                    b.HasIndex("idUser");

                    b.ToTable("JobCoordination");
                });

            modelBuilder.Entity("hunterview.Models.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<bool>("Seen");

                    b.Property<string>("Subject");

                    b.Property<int>("TypeId");

                    b.Property<int>("TypeNotif");

                    b.Property<string>("UserId");

                    b.HasKey("NotificationId");

                    b.HasIndex("UserId");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("hunterview.Models.QuestionSeen", b =>
                {
                    b.Property<int>("QuestionSeenId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("QuestionId");

                    b.Property<string>("userId");

                    b.HasKey("QuestionSeenId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("userId");

                    b.ToTable("QuestionSeen");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Domain.Comment", b =>
                {
                    b.HasOne("Domain.Status", "Status")
                        .WithMany("Commentss")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("hunterview.Models.ApplicationUser", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Domain.CommentaireJob", b =>
                {
                    b.HasOne("hunterview.Models.ApplicationUser", "User")
                        .WithMany("CommentairesJobs")
                        .HasForeignKey("IdUser");

                    b.HasOne("Domain.Job", "Job")
                        .WithMany("Commentaires")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Experience", b =>
                {
                    b.HasOne("Domain.Speciality", "Speciality")
                        .WithMany()
                        .HasForeignKey("SpecialityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("hunterview.Models.ApplicationUser", "Jobseeker")
                        .WithMany()
                        .HasForeignKey("userId");
                });

            modelBuilder.Entity("Domain.JaimeJob", b =>
                {
                    b.HasOne("Domain.Job", "Job")
                        .WithMany("JaimeJobs")
                        .HasForeignKey("idJob")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("hunterview.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("idUser");
                });

            modelBuilder.Entity("Domain.Job", b =>
                {
                    b.HasOne("hunterview.Models.Company", "Company")
                        .WithMany("Jobs")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Speciality", "Speciality")
                        .WithMany("Jobs")
                        .HasForeignKey("SpecilityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("hunterview.Models.ApplicationUser", "Headhunter")
                        .WithMany()
                        .HasForeignKey("testId");
                });

            modelBuilder.Entity("Domain.LanguageUser", b =>
                {
                    b.HasOne("hunterview.Models.ApplicationUser", "User")
                        .WithMany("LanguageUsers")
                        .HasForeignKey("idUser");
                });

            modelBuilder.Entity("Domain.LikeComments", b =>
                {
                    b.HasOne("Domain.Comment", "Comment")
                        .WithMany("LikeComments")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("hunterview.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("idUser");
                });

            modelBuilder.Entity("Domain.Message", b =>
                {
                    b.HasOne("hunterview.Models.ApplicationUser", "Receiver")
                        .WithMany()
                        .HasForeignKey("Receiver_Id");

                    b.HasOne("hunterview.Models.ApplicationUser", "Sender")
                        .WithMany()
                        .HasForeignKey("Sender_Id");
                });

            modelBuilder.Entity("Domain.Question", b =>
                {
                    b.HasOne("Domain.Speciality", "Speciality")
                        .WithMany("Questions")
                        .HasForeignKey("SpecialityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Response", b =>
                {
                    b.HasOne("Domain.Question", "Question")
                        .WithMany("Responses")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Status", b =>
                {
                    b.HasOne("hunterview.Models.ApplicationUser", "JobSeeker")
                        .WithMany("Status")
                        .HasForeignKey("testId");
                });

            modelBuilder.Entity("Domain.UserHobies", b =>
                {
                    b.HasOne("hunterview.Models.ApplicationUser", "User")
                        .WithMany("UserHobies")
                        .HasForeignKey("idUser");
                });

            modelBuilder.Entity("Domain.WorkExperience", b =>
                {
                    b.HasOne("hunterview.Models.ApplicationUser", "User")
                        .WithMany("WorkExperiences")
                        .HasForeignKey("idUser");
                });

            modelBuilder.Entity("hunterview.Models.Answer", b =>
                {
                    b.HasOne("Domain.Response", "Response")
                        .WithMany("Answers")
                        .HasForeignKey("IdResponse")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("hunterview.Models.ApplicationUser", "User")
                        .WithMany("Answers")
                        .HasForeignKey("IdUser");
                });

            modelBuilder.Entity("hunterview.Models.ApplicationUser", b =>
                {
                    b.HasOne("hunterview.Models.ApplicationUser", "LastHeadHunter")
                        .WithMany()
                        .HasForeignKey("testId");
                });

            modelBuilder.Entity("hunterview.Models.Favorite", b =>
                {
                    b.HasOne("hunterview.Models.Company", "Company")
                        .WithMany("Favorites")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("hunterview.Models.ApplicationUser", "User")
                        .WithMany("Favorites")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("hunterview.Models.JobCoordination", b =>
                {
                    b.HasOne("Domain.Job", "Job")
                        .WithMany("JobCoordinations")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("hunterview.Models.ApplicationUser", "Jobseeker")
                        .WithMany("JobCoordinations")
                        .HasForeignKey("idUser");
                });

            modelBuilder.Entity("hunterview.Models.Notification", b =>
                {
                    b.HasOne("hunterview.Models.ApplicationUser", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("hunterview.Models.QuestionSeen", b =>
                {
                    b.HasOne("Domain.Question", "Question")
                        .WithMany("QuestionSeens")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("hunterview.Models.ApplicationUser", "user")
                        .WithMany("QuestionSeens")
                        .HasForeignKey("userId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("hunterview.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("hunterview.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("hunterview.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
