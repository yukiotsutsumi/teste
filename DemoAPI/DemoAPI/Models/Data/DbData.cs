using DemoAPI.Models.Classes;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Models.Data
{
    public class DbData
    {
        private readonly DbApontamentoHoras _dbApontamentoHoras;

        public DbData(DbApontamentoHoras dbApontamentoHoras)
        {
            _dbApontamentoHoras = dbApontamentoHoras;
        }

        public ApontamentoDeHoras CadastrarApontamentoHoras(ApontamentoDeHoras novoApontamento)
        {
            _dbApontamentoHoras.ApontamentoDeHoras.Add(novoApontamento);
            _dbApontamentoHoras.SaveChanges();
            return novoApontamento;
        }

        public List<ApontamentoDeHoras> ListarApontamentoHoras()
        {
            var listaDeApontamentos = _dbApontamentoHoras.ApontamentoDeHoras.AsNoTracking().ToList();
            return listaDeApontamentos;
        }

        public ApontamentoDeHoras UpdateApontamento(ApontamentoDeHoras editadoFuncionario)
        {
            _dbApontamentoHoras.ApontamentoDeHoras.Update(editadoFuncionario);
            _dbApontamentoHoras.SaveChanges();
            return editadoFuncionario;
        }

        public List<ApontamentoDeHoras> UpdateApontamento(int id)
        {
            var apontamentoParaExcluir = _dbApontamentoHoras.ApontamentoDeHoras.Find(id);

            _dbApontamentoHoras.ApontamentoDeHoras.Remove(apontamentoParaExcluir);
            _dbApontamentoHoras.SaveChanges();
            return ListarApontamentoHoras();
        }
    }
}
