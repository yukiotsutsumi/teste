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

        public Tratamento<ApontamentoDeHoras> CadastrarApontamentoHoras(ApontamentoDeHoras novoApontamento)
        {
            Tratamento<ApontamentoDeHoras> tratamento = new Tratamento<ApontamentoDeHoras>();
            try
            {
                tratamento.Dados = novoApontamento;
                if (novoApontamento == null)
                {
                    tratamento.AdicionarErro();
                    return tratamento;
                }
                if (tratamento.Dados.TempoTotal == "Erro")
                {
                    tratamento.AdicionarErro();
                }
                else
                {
                    _dbApontamentoHoras.ApontamentoDeHoras.Add(novoApontamento);
                    _dbApontamentoHoras.SaveChanges();
                }
            }
            catch(Exception)
            {
                tratamento.AdicionarErro();
            }
            return tratamento;    
        }

        public Tratamento <List<ApontamentoDeHoras>> ListarApontamentoHoras()
        {
            Tratamento<List<ApontamentoDeHoras>> tratamento = new Tratamento<List<ApontamentoDeHoras>>();

            try
            {
                tratamento.Dados = _dbApontamentoHoras.ApontamentoDeHoras.ToList();

                if (tratamento.Dados.Count() == 0)
                {
                    tratamento.AdicionarErro();
                }
            }
            catch (Exception ex)
            {
                tratamento.AdicionarErro();
            }
             return tratamento;
        }

        public Tratamento<ApontamentoDeHoras>  UpdateApontamento(ApontamentoDeHoras editadoFuncionario)
        {

            Tratamento<ApontamentoDeHoras> tratamento = new Tratamento<ApontamentoDeHoras>();
            try
            {
                tratamento.Dados = editadoFuncionario;
                ApontamentoDeHoras apontamentoValue = _dbApontamentoHoras.ApontamentoDeHoras.AsNoTracking().FirstOrDefault(x => x == editadoFuncionario);

                if (apontamentoValue == null)
                {
                    tratamento.AdicionarErro();
                    return tratamento;
                }
                if (tratamento.Dados.TempoTotal == "Erro")
                {
                    tratamento.AdicionarErro();
                }
                else
                {
                    _dbApontamentoHoras.ApontamentoDeHoras.Update(editadoFuncionario);
                    _dbApontamentoHoras.SaveChanges();
                }
            }
            
            catch (Exception ex)
            {
                tratamento.AdicionarErro();
            }
            return tratamento;
        }

        public Tratamento<ApontamentoDeHoras> RemoveApontamento(int id)
        {

            Tratamento<ApontamentoDeHoras> tratamento = new Tratamento<ApontamentoDeHoras>();

            try
            {
                ApontamentoDeHoras apontamentoValue = _dbApontamentoHoras.ApontamentoDeHoras.AsNoTracking().FirstOrDefault(x => x.Id == id);

                if (apontamentoValue == null)
                {
                    tratamento.AdicionarErro();
                }
                else
                {
                    _dbApontamentoHoras.ApontamentoDeHoras.Remove(apontamentoValue);
                    _dbApontamentoHoras.SaveChanges();
                    tratamento.Dados = apontamentoValue;
                }
            }

            catch (Exception ex)
            {
                tratamento.AdicionarErro();
            }
            return tratamento;
        }
    }
}
