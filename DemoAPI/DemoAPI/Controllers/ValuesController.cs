using DemoAPI.Models.Classes;
using DemoAPI.Models.Data;
using Microsoft.AspNetCore.Mvc;

[Route("api/listarhoras")]
[ApiController]
public class ValuesController : ControllerBase
{
    private readonly DbData _dbData;
    public ValuesController(DbData dbData)
    {
         _dbData = dbData;
    }
    [HttpGet]
    public ActionResult<List<ApontamentoDeHoras>> GetFuncionario()
    {
        return Ok(_dbData.ListarApontamentoHoras());
    }
    [HttpPost]
    public ActionResult<List<ApontamentoDeHoras>> PostFuncionario([FromBody] ApontamentoDeHoras novoApontamento)
    {
        var apontamentos = _dbData.CadastrarApontamentoHoras(novoApontamento);
        return Ok(apontamentos);
    }
    [HttpPut]
    public ActionResult<ApontamentoDeHoras> UpdateFuncionario(ApontamentoDeHoras editadoFuncionario)
    {
        var editFuncionario = _dbData.UpdateFuncionario(editadoFuncionario);
        return Ok(editFuncionario);
    }

    [HttpDelete]
    public ActionResult<List<ApontamentoDeHoras>> DeleteFuncionario(int id)
    {
        var idFuncionario = _dbData.DeleteFuncionario(id);
        return Ok(idFuncionario);
    }
}
