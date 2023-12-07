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

        public TratamentoErros<ApontamentoDeHoras> CadastrarApontamentoHoras(ApontamentoDeHoras novoApontamento)
        {
            TratamentoErros<ApontamentoDeHoras> tratamentoErros = new TratamentoErros<ApontamentoDeHoras>();

            try
            {
                if (novoApontamento == null)
                {
                    tratamentoErros.Dados = null;
                    tratamentoErros.Mensagem = "Informar dados";
                    tratamentoErros.Sucesso = false;

                    return tratamentoErros;
                }

                _dbApontamentoHoras.ApontamentoDeHoras.Add(novoApontamento);
                _dbApontamentoHoras.SaveChanges();

                tratamentoErros.Mensagem = "Apontamento cadastrado com sucesso";
                tratamentoErros.Dados = novoApontamento;
            }
            catch(Exception ex)
            {
                tratamentoErros.Mensagem = ex.Message;
                tratamentoErros.Sucesso = false;
            }

            return tratamentoErros;    
        }

        public TratamentoErros <List<ApontamentoDeHoras>> ListarApontamentoHoras()
        {
            TratamentoErros<List<ApontamentoDeHoras>> tratamentoErros = new TratamentoErros<List<ApontamentoDeHoras>>();

            try
            {
                tratamentoErros.Dados = _dbApontamentoHoras.ApontamentoDeHoras.ToList();

                if (tratamentoErros.Dados.Count() == 0)
                {
                    tratamentoErros.Mensagem = "Nenhum dado encontrado";
                }

                tratamentoErros.Mensagem = "Apontamento listado com sucesso";

            }
            catch (Exception ex)
            {
                tratamentoErros.Mensagem = ex.Message;
                tratamentoErros.Sucesso = false;
            }

             return tratamentoErros;
        }

        public TratamentoErros<List<ApontamentoDeHoras>>  UpdateApontamento(ApontamentoDeHoras editadoFuncionario)
        {

            TratamentoErros<List<ApontamentoDeHoras>> tratamentoErros = new TratamentoErros<List<ApontamentoDeHoras>>();

            try
            {
                ApontamentoDeHoras apontamentoValue = _dbApontamentoHoras.ApontamentoDeHoras.AsNoTracking().FirstOrDefault(x => x == editadoFuncionario);

                if (apontamentoValue == null)
                {
                    tratamentoErros.Dados = null;
                    tratamentoErros.Mensagem = "Usuario não localizado";
                    tratamentoErros.Sucesso = false;
                }

                _dbApontamentoHoras.ApontamentoDeHoras.Update(editadoFuncionario);
                _dbApontamentoHoras.SaveChanges();

                tratamentoErros.Mensagem = "Apontamento atualizado com sucesso";
                tratamentoErros.Dados = _dbApontamentoHoras.ApontamentoDeHoras.ToList();
            }

            catch (Exception ex)
            {
                tratamentoErros.Mensagem = ex.Message;
                tratamentoErros.Sucesso = false;
            }

            return tratamentoErros;
        }

        public TratamentoErros<ApontamentoDeHoras> RemoveApontamento(int id)
        {

            TratamentoErros<ApontamentoDeHoras> tratamentoErros = new TratamentoErros<ApontamentoDeHoras>();

            try
            {
                ApontamentoDeHoras apontamentoValue = _dbApontamentoHoras.ApontamentoDeHoras.AsNoTracking().FirstOrDefault(x => x.Id == id);
    
                if (apontamentoValue == null)
                {
                    tratamentoErros.Dados = null;
                    tratamentoErros.Mensagem = "Usuario não localizado";
                    tratamentoErros.Sucesso = false;
                }

                _dbApontamentoHoras.ApontamentoDeHoras.Remove(apontamentoValue);
                _dbApontamentoHoras.SaveChanges();

                tratamentoErros.Mensagem = "Apontamento deletado com sucesso";
                tratamentoErros.Dados = apontamentoValue;
            }

            catch (Exception ex)
            {
                tratamentoErros.Mensagem = ex.Message;
                tratamentoErros.Sucesso = false;
            }

            return tratamentoErros;

            
        }
    }
}
