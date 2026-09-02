using Microsoft.EntityFrameworkCore;
using ERP.Domain.Models;

namespace ERP.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

}
