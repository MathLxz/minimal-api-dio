using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.Dominio.Entidades;

namespace minimal_api.Dominio.Interfaces
{
    public interface IServicoVeiculo
    {
         List<Veiculo> Todos (int pagina = 1, string modelo = null,  string marca = null);
         Veiculo BuscaPorId(int id);
         void CadastrarVeiculo(Veiculo veiculo);
         void AtualizarVeiculo(Veiculo veiculo);
         void ApagarId(Veiculo veiculo);
    }
}