using Erkan.ToDo.DataAccess.Concrete.EntityFramework.Mapping;
using Erkan.ToDo.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erkan.ToDo.DataAccess.Concrete.EntityFramework.Contexts
{
    public class ToDoContext:IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB; database=BlogToDo; integrated security=true;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskMap());
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new ReportMap());
            modelBuilder.ApplyConfiguration(new ImportanceMap());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Importance> Importances { get; set; }
        public DbSet<Report> Reports { get; set; }

    }
}
