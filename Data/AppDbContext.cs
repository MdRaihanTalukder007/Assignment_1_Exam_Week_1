using Assignment_1_Exam_Week_1.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assignment_1_Exam_Week_1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public virtual DbSet<UserDetail> UserDetails { get; set; }
    }
}
