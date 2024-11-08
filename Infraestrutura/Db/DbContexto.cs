using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.Entidades;

namespace minimal_api.Infraestrutura.Db
{
    public class DbContexto(IConfiguration configAppSettings) : DbContext
    {
        private readonly IConfiguration _configAppSettings = configAppSettings;

        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>().HasData(
                new Administrador{
                    Id = 1,
                    Email = "administrador@email.com",
                    Senha="123456",
                    Perfil="Adm"
                }
            );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                var conexaoBanco = _configAppSettings.GetConnectionString("ConexaoPadrao").ToString();
                if (!string.IsNullOrEmpty(conexaoBanco))
                {

                    optionsBuilder.UseSqlServer(conexaoBanco);
                }
            }

        }

    }

}