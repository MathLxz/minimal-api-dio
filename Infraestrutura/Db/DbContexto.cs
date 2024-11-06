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