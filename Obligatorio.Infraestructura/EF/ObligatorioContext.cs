using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.Infraestructura.EF
{
    public class ObligatorioContext : DbContext
    {
        public ObligatorioContext(DbContextOptions<ObligatorioContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Historia> Historias { get; set; }
        public DbSet<Capitulo> Capitulos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>().OwnsOne(u => u.Contrasenia);
            modelBuilder.Entity<Usuario>().OwnsOne(u => u.Rol);
            modelBuilder.Entity<Usuario>().OwnsOne(u => u.Email);

            modelBuilder.Entity<Capitulo>()
                .HasDiscriminator<string>("TipoCapitulo")
                .HasValue<CapituloIntermedio>("Intermedio")
                .HasValue<CapituloFinal>("Final");

            modelBuilder.Entity<Historia>()
                .HasMany(h => h.Categorias)
                .WithMany();


            modelBuilder.Entity<Historia>()
                .HasOne(h => h.CapituloInicial)
                .WithMany()
                .HasForeignKey("CapituloInicialId")
                .OnDelete(DeleteBehavior.Restrict);
            

            modelBuilder.Entity<CapituloIntermedio>()
                .HasMany(c => c.Opciones)
                .WithOne()
                .HasForeignKey("CapituloId")
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Opcion>()
                .HasOne(o => o.Destino)
                .WithMany()
                .HasForeignKey("CapituloDestinoId")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Historia>()
                .HasMany(h => h.Capitulos)
                .WithOne()
                .HasForeignKey("HistoriaId")
                .OnDelete(DeleteBehavior.Cascade);
        }
        
    }
}