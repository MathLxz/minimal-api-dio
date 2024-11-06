using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Interfaces;
using minimal_api.Infraestrutura.Db;

namespace minimal_api.Dominio.Servicos
{
    public class ServicoVeiculo(DbContexto contexto) : IServicoVeiculo
    {
        private readonly DbContexto _contexto = contexto;

        // Lista todos os veiculos
        public List<Veiculo> Todos(int pagina = 1, string modelo = null, string marca = null)
        {
            var query = _contexto.Veiculos.AsQueryable();
            if (!string.IsNullOrEmpty(modelo))
            {
                query = query.Where(v => EF.Functions.Like(v.Modelo.ToLower(), $"%{modelo}%"));
            }
            int itensPorPagina = 10;
            query = query.Skip((pagina - 1) * itensPorPagina).Take(itensPorPagina);
            return [.. query];
        }
        // Busca veiculo por ID
        public Veiculo BuscaPorId(int id)
        {
           return _contexto.Veiculos.Where(v => v.Id == id).FirstOrDefault();
        }

        public void CadastrarVeiculo(Veiculo veiculo)
        {
           _contexto.Veiculos.Add(veiculo);
           _contexto.SaveChanges();
        }

        public void AtualizarVeiculo(Veiculo veiculo)
        {
            _contexto.Veiculos.Update(veiculo);
            _contexto.SaveChanges();
        }

        public void ApagarId(Veiculo veiculo)
        {
            _contexto.Veiculos.Remove(veiculo);
            _contexto.SaveChanges();
            
        }
    }
}