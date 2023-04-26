using Crud.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud.Data;

public class EmpresaContext : DbContext
{
    public EmpresaContext(DbContextOptions<EmpresaContext>opts) : base(opts) 
    {
        
    }

    public DbSet<Empresa> Empresas { get; set; }


}
