using CQRS_Test_Project.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using File = CQRS_Test_Project.Core.Domain.Entities.File;
using Task = CQRS_Test_Project.Core.Domain.Entities.Task;

namespace CQRS_Test_Project.Infrastructure.Persistence.Context
{
    public class CqrsContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=dpg-d0l461buibrs73a0sjpg-a.oregon-postgres.render.com;Database=taskmanager_flx4;User Id=taskmanager_flx4_user;Password=M2wc9dwLVJgf47dLegk7bn2OetGFMquV;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Task>()
                .Property(t => t.BaseID);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<SubTask> SubTasks { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TaskTag> TaskTags { get; set; }
        public DbSet<Efor> Efors { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Workflow> Workflows { get; set; }
    }
}