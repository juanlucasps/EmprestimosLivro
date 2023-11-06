using EmprestimosLivro.Models;
using Microsoft.EntityFrameworkCore;

namespace EmprestimosLivro.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<EmprestimosModel> EmprestimosLivro { get; set;}
    }
}
