using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace webapi.Models
{
    public partial class traderapp_qatarContext : DbContext
    {
         public traderapp_qatarContext(DbContextOptions<traderapp_qatarContext> options)
        : base(options)
    {
    }

        public virtual DbSet<CatStatusJuego> CatStatusJuegos { get; set; }
        public virtual DbSet<CatTipoLiga> CatTipoLigas { get; set; }
        public virtual DbSet<CatTipoUsuario> CatTipoUsuarios { get; set; }
        public virtual DbSet<Equipo> Equipos { get; set; }
        public virtual DbSet<Estadio> Estadios { get; set; }
        public virtual DbSet<Fasegrupo> Fasegrupos { get; set; }
        public virtual DbSet<FasegruposResultado> FasegruposResultados { get; set; }
        public virtual DbSet<Grupo> Grupos { get; set; }
        public virtual DbSet<Liga> Ligas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Usuarioliga> Usuarioligas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatStatusJuego>(entity =>
            {
                entity.ToTable("cat_status_juego");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_creacion");
            });

            modelBuilder.Entity<CatTipoLiga>(entity =>
            {
                entity.ToTable("cat_tipo_liga");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<CatTipoUsuario>(entity =>
            {
                entity.ToTable("cat_tipo_usuario");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_creacion");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.ToTable("equipo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_creacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_modificacion");

                entity.Property(e => e.Grupo).HasColumnName("grupo");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Pe).HasColumnName("pe");

                entity.Property(e => e.Pg).HasColumnName("pg");

                entity.Property(e => e.Pj).HasColumnName("pj");

                entity.Property(e => e.Pp).HasColumnName("pp");

                entity.Property(e => e.Puntos).HasColumnName("puntos");

                entity.HasOne(d => d.GrupoNavigation)
                    .WithMany(p => p.Equipos)
                    .HasForeignKey(d => d.Grupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_EquipoGrupo");
            });

            modelBuilder.Entity<Estadio>(entity =>
            {
                entity.ToTable("estadio");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_creacion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Fasegrupo>(entity =>
            {
                entity.ToTable("fasegrupos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Equipoa).HasColumnName("equipoa");

                entity.Property(e => e.Equipob).HasColumnName("equipob");

                entity.Property(e => e.Estadio).HasColumnName("estadio");

                entity.Property(e => e.EstadoJuego).HasColumnName("estado_juego");

                entity.Property(e => e.EquipoaGol).HasColumnName("equipoa_gol");

                entity.Property(e => e.EquipobGol).HasColumnName("equipob_gol");

                entity.Property(e => e.Fechayhora)
                    .HasColumnType("datetime")
                    .HasColumnName("fechayhora");

                entity.Property(e => e.Grupo).HasColumnName("grupo");

                entity.HasOne(d => d.EquipoaNavigation)
                    .WithMany(p => p.FasegrupoEquipoaNavigations)
                    .HasForeignKey(d => d.Equipoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_fasegrupos_equipo");

                entity.HasOne(d => d.EquipobNavigation)
                    .WithMany(p => p.FasegrupoEquipobNavigations)
                    .HasForeignKey(d => d.Equipob)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_fasegrupos_equipo1");

                entity.HasOne(d => d.EstadioNavigation)
                    .WithMany(p => p.Fasegrupos)
                    .HasForeignKey(d => d.Estadio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_fasegrupos_estadio");

                entity.HasOne(d => d.EstadoJuegoNavigation)
                    .WithMany(p => p.Fasegrupos)
                    .HasForeignKey(d => d.EstadoJuego)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_fasegrupos_cat_status_juego1");
            });

            modelBuilder.Entity<FasegruposResultado>(entity =>
            {
                entity.ToTable("fasegrupos_resultado");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EquipoaGol).HasColumnName("equipoa_gol");

                entity.Property(e => e.EquipobGol).HasColumnName("equipob_gol");

                entity.Property(e => e.Grupo).HasColumnName("grupo");

                entity.Property(e => e.IdEquipoa).HasColumnName("id_equipoa");

                entity.Property(e => e.IdEquipob).HasColumnName("id_equipob");

                entity.Property(e => e.Idjuego).HasColumnName("idjuego");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.GrupoNavigation)
                    .WithMany(p => p.FasegruposResultados)
                    .HasForeignKey(d => d.Grupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_fasegrupos_resultado_grupo");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FasegruposResultados)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_fasegrupos_resultado_usuario");

                entity.HasOne(d => d.FaseGrupoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idjuego)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_fasegrupos_resultado_fasegrupos");

            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.ToTable("grupo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Grupo1)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("grupo")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Liga>(entity =>
            {
                entity.ToTable("liga");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatorUserid).HasColumnName("creator_userid");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_creacion");

                entity.Property(e => e.IdTipoLiga).HasColumnName("id_tipo_liga");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdTipoLigaNavigation)
                    .WithMany(p => p.Ligas)
                    .HasForeignKey(d => d.IdTipoLiga)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_liga_cat_tipo_liga");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("pass");

                entity.Property(e => e.Puntos).HasColumnName("puntos");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tipo).HasColumnName("tipo");

                entity.HasOne(d => d.TipoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Tipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_usuario_cat_tipo_usuario");
            });

            modelBuilder.Entity<Usuarioliga>(entity =>
            {
                entity.ToTable("usuarioliga");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Idliga).HasColumnName("idliga");

                entity.Property(e => e.Idusuario).HasColumnName("idusuario");

                entity.Property(e => e.MontoApuesta)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("monto_apuesta");

                entity.HasOne(d => d.IdligaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idliga)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_usuarioliga_liga");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_usuarioliga_usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
