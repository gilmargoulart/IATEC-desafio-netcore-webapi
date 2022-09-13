using Microsoft.EntityFrameworkCore;

namespace IATEC_desafio.Common.Models
{
    public class IATECContext : DbContext
    {
        public IATECContext(DbContextOptions<IATECContext> options)
            : base(options)
        {
            //
        }

        public DbSet<Vendedor> Vendedores { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<PedidoItem> PedidoItens { get; set; }
        
    }
}