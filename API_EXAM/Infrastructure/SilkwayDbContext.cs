using API_EXAM;
using API_EXAM.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure
{
    public partial class EXAMDbContext : DbContext
    {
        public EXAMDbContext(DbContextOptions<EXAMDbContext> options)
           : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }



        public DbSet<EXAMS> EXAMS { get; set; }
        public DbSet<STUDENTS> STUDENTS { get; set; }
        public DbSet<LESSONS> LESSONS { get; set; }

    }
}
