using Microsoft.EntityFrameworkCore;
//using ApiAzureDB.Modelo; // Asegúrate de que este using esté activo si tus modelos están en esa carpeta

namespace ApiAzureDB.Data {
    public class AplicacionDbContext : DbContext {
        public AplicacionDbContext(DbContextOptions<AplicacionDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<CarpetaTematica> CarpetasTematicas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<DocumentoCarpeta> DocumentoCarpetas { get; set; }
        public DbSet<DocumentoCategoria> DocumentoCategorias { get; set; }
        public DbSet<Noticia> Noticias { get; set; }
        public DbSet<Notificacion> Notificaciones { get; set; }
        public DbSet<LogAuditoria> LogsAuditoria { get; set; }
        public DbSet<DocumentoDescargado> DocumentosDescargados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>().HasKey(u => u.UsuarioID);
            modelBuilder.Entity<CarpetaTematica>().HasKey(c => c.CarpetaID);
            modelBuilder.Entity<Categoria>().HasKey(c => c.CategoriaID);
            modelBuilder.Entity<Documento>().HasKey(d => d.DocumentoID);
            modelBuilder.Entity<Noticia>().HasKey(n => n.NoticiaID);
            modelBuilder.Entity<Notificacion>().HasKey(n => n.NotificacionID);
            modelBuilder.Entity<LogAuditoria>().HasKey(l => l.LogID);
            modelBuilder.Entity<DocumentoDescargado>().HasKey(d => d.DescargaID);


            modelBuilder.Entity<DocumentoCarpeta>()
                .HasKey(dc => new { dc.DocumentoID, dc.CarpetaID });

            modelBuilder.Entity<DocumentoCategoria>()
                .HasKey(dc => new { dc.DocumentoID, dc.CategoriaID });
        }
    }
}