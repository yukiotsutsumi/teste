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
                    tratamento.Dados = null;
                    tratamento.Mensagem = "Informar dados";
                    tratamento.Sucesso = false;

                    return tratamento;
                }
                if (tratamento.Dados.TempoTotal == "Erro")
                {
                    tratamento.Dados = null;
                    tratamento.Mensagem = "Horário inválido";
                    tratamento.Sucesso = false;
                }
                else
                {
                    _dbApontamentoHoras.ApontamentoDeHoras.Add(novoApontamento);
                    _dbApontamentoHoras.SaveChanges();

                    tratamento.Mensagem = "Apontamento cadastrado com sucesso";
                }
            }
            catch(Exception ex)
            {
                tratamento.Mensagem = "Erro ao cadastrar apontamento: " + ex;
                tratamento.Sucesso = false;
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
                    tratamento.Mensagem = "Nenhum dado encontrado";
                }

                tratamento.Mensagem = "Apontamento listado com sucesso";

            }
            catch (Exception ex)
            {
                tratamento.Mensagem = "Erro ao listar apontamentos: " + ex;
                tratamento.Sucesso = false;
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
                    tratamento.Dados = null;
                    tratamento.Mensagem = "Usuario não localizado";
                    tratamento.Sucesso = false;
                    return tratamento;

                }
                if (tratamento.Dados.TempoTotal == "Erro")
                {
                    tratamento.Dados = null;
                    tratamento.Mensagem = "Horário inválido. Não foi possível atualizar o apontamento.";
                    tratamento.Sucesso = false;
                }
                else
                {
                    _dbApontamentoHoras.ApontamentoDeHoras.Update(editadoFuncionario);
                    _dbApontamentoHoras.SaveChanges();

                    tratamento.Mensagem = "Apontamento atualizado com sucesso";
                }
            }
            
            catch (Exception ex)
            {
                tratamento.Mensagem = "Erro ao atualizar apontamento: " + ex;
                tratamento.Sucesso = false;
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
                    tratamento.Dados = null;
                    tratamento .Mensagem = "Usuario não localizado";
                    tratamento.Sucesso = false;
                }

                _dbApontamentoHoras.ApontamentoDeHoras.Remove(apontamentoValue);
                _dbApontamentoHoras.SaveChanges();

                tratamento.Mensagem = "Apontamento deletado com sucesso";
                tratamento.Dados = apontamentoValue;
            }

            catch (Exception ex)
            {
                tratamento.Mensagem = "Erro ao deletar apontamento: " + ex;
                tratamento.Sucesso = false;
            }
            return tratamento;
        }
    }
}
