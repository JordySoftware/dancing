using Back_Factura.Model;
using Microsoft.EntityFrameworkCore;

namespace Back_Factura.Data
{
    public class FacturaDBContext : DbContext
    {
        public FacturaDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Factura> Facturas { get; set; }
    }
}
