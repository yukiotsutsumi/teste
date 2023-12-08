using DemoAPI.Models.Classes;
using DemoAPI.Models.Data;
using Microsoft.AspNetCore.Mvc;

[Route("api")]
[ApiController]
public class ApontamentoController : ControllerBase
{
    private readonly DbData _dbData;
    public ApontamentoController(DbData dbData)
    {
         _dbData = dbData;
    }
    [HttpGet("/listarApontamentos")]
    public ActionResult<List<ApontamentoDeHoras>> GetFuncionario()
    {
        var resposta = _dbData.ListarApontamentoHoras();
        if (resposta.Sucesso)
        {
            return Ok(resposta);
        }
        else
        {
            return BadRequest("Não foi possível listar os apontamentos.");
        }
    }
    [HttpPost("/cadastrarApontamento")]
    public ActionResult <ApontamentoDeHoras> PostApontamento([FromBody] ApontamentoDeHoras novoApontamento)
    {
        var resposta = _dbData.CadastrarApontamentoHoras(novoApontamento);
        if (resposta.Sucesso)
        {
            return Ok(resposta);
        }
        else
        {
            return BadRequest("Não foi possível cadastrar o apontamento.");
        }
    }
    [HttpPut("/atualizarApontamento")]
    public ActionResult<ApontamentoDeHoras> UpdateApontamento(ApontamentoDeHoras editadoFuncionario)
    {
        var resposta = _dbData.UpdateApontamento(editadoFuncionario);
        if (resposta.Sucesso)
        {
            return Ok(resposta);
        }
        else
        {
            return BadRequest("Não foi possível atualizar o apontamento.");
        }
    }

    [HttpDelete("/deletarApontamento")]
    public ActionResult<ApontamentoDeHoras> DeleteApontamento(int id)
    {
        var resposta = _dbData.RemoveApontamento(id);
        if (resposta.Sucesso)
        {
            return Ok(resposta);
        }
        else
        {
            return BadRequest("Não foi possível deletar o apontamento.");
        }
    }
}
