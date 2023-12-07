using DemoAPI.Models.Classes;
using DemoAPI.Models.Data;
using Microsoft.AspNetCore.Mvc;

[Route("api")]
[ApiController]
public class ValuesController : ControllerBase
{
    private readonly DbData _dbData;
    public ValuesController(DbData dbData)
    {
         _dbData = dbData;
    }
    [HttpGet("/listarApontamentos")]
    public ActionResult<List<ApontamentoDeHoras>> GetFuncionario()
    {
        return Ok(_dbData.ListarApontamentoHoras());
    }
    [HttpPost("/cadastrarApontamento")]
    public ActionResult<List<ApontamentoDeHoras>> PostApontamento([FromBody] ApontamentoDeHoras novoApontamento)
    {
            var apontamentos = _dbData.CadastrarApontamentoHoras(novoApontamento);
            return Ok(apontamentos);
    }
    [HttpPut("/atualizarApontamento")]
    public ActionResult<ApontamentoDeHoras> UpdateApontamento(ApontamentoDeHoras editadoFuncionario)
    {
        var editFuncionario = _dbData.UpdateApontamento(editadoFuncionario);
        return Ok(editFuncionario);
    }

    [HttpDelete("/deletarApontamento")]
    public ActionResult<List<ApontamentoDeHoras>> DeleteApontamento(int id)
    {
        var idFuncionario = _dbData.UpdateApontamento(id);
        return Ok(idFuncionario);
    }
}
