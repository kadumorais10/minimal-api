using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Entidades;

namespace MinimalApi.Infraestrutura.Db;

public class DbContexto : DbContext
{
    // CONSTRUTOR ESSENCIAL para que AddDbContext use as options configuradas
    public DbContexto(DbContextOptions<DbContexto> options) : base(options)
    {
    }

    public DbContexto() { }

    public DbSet<Administrador> Administradores { get; set; } = default!;
    public DbSet<Veiculo> Veiculos { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>().ToTable("Administradores");

        modelBuilder.Entity<Administrador>().HasData(
            new Administrador
            {
                Id = -1,
                Email = "Administrador@teste.com",
                Senha = "123456",
                Perfil = "Adm"
                // -- se Administrador tiver outras propriedades obrigatórias,
                //    coloque-as aqui também (ex.: Nome = "Admin")
            }
        );

        base.OnModelCreating(modelBuilder);
    }
}

   

    

    // Se precisar configurar algo extra, pode sobrescrever OnModelCreating
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     base.OnModelCreating(modelBuilder);

    //     // Exemplo: configurando tabela Administradores
    //     modelBuilder.Entity<Administrador>().ToTable("Administradores");
    // }

