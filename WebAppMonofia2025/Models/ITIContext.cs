using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAppMonofia2025.Models
{
    public class ITIContext :IdentityDbContext<ApplicationUser>
    {
        //declare properties Bto Table
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }

        public ITIContext()//Compatitlity
        {
            
        }
        //IOC Continaer to resolve ITIContexxt service if Inject
        public ITIContext(DbContextOptions<ITIContext> options):base(options) { }
        

        #region   DbContext Option
        //DBMS :Sql Serve
        //Server NAme :.
        //Authantication :Windows
        //DataBase Name
        #endregion

        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=M9M25;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
