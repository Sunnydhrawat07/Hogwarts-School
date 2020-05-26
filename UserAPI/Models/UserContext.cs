using Microsoft.EntityFrameworkCore;


namespace UserAPI.Models
{
public class UserContext: DbContext
{
public UserContext(DbContextOptions<UserContext> options) :base (options)
{

}
        public DbSet<Student> Students {get;set;}
        public DbSet<Staff> Staff {get;set;}
        public DbSet<Teacher> Teachers {get;set;}
        public DbSet<StudentResult> StudentResults {get;set;}
        public DbSet<Assessment> Assessments {get;set;}
        public DbSet<StudentProspect> StudentProspects {get;set;}

}
}

