using Microsoft.EntityFrameworkCore;
using MyExcelApp.MvcApp.Models;

namespace MyExcelApp.MvcApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
