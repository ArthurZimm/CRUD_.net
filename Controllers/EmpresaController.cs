using AutoMapper;
using Crud.Data;
using Crud.Data.Dtos;
using Crud.Models;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
namespace Crud.Controllers;

[ApiController]
[Route("[controller]")]
public class EmpresaController : ControllerBase
{
    private EmpresaContext _context;

    private IMapper _mapper;

    public EmpresaController(EmpresaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaEmpresa([FromBody] CreateEmpresaDto empresaDto)
    {
        Empresa empresa = _mapper.Map<Empresa>(empresaDto); 
        _context.Empresas.Add(empresa);
        _context.SaveChanges();
        return CreatedAtAction(nameof(empresa), new { id = empresa.IdEmpresa }, empresa);
    }

    [HttpGet]
    public IEnumerable<ReadEmpresasDto> RecuperaEmpresa([FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        return _mapper.Map<List<ReadEmpresasDto>>(_context.Empresas.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaEmpresaPorID(int id)
    {
        var empresa = _context.Empresas.FirstOrDefault(empresa => empresa.IdEmpresa == id);
        if (empresa == null) return NotFound();
        var empresaDto = _mapper.Map<ReadEmpresasDto>(empresa);
        return Ok(empresa);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaEmpresa(int id,
        [FromBody] UpdateEmpresaDto empresaDto)
    {
        var empresa = _context.Empresas.FirstOrDefault(
            empresa => empresa.IdEmpresa == id);
        if (empresa == null) return NotFound();
        _mapper.Map(empresaDto, empresa );
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaEmpresaParcial(int id,JsonPatchDocument<UpdateEmpresaDto> patch)
    {
        var empresa = _context.Empresas.FirstOrDefault(
            empresa => empresa.IdEmpresa == id);
        if (empresa == null) return NotFound();

        var empresaParaAtualizar = _mapper.Map<UpdateEmpresaDto>(empresa);

        patch.ApplyTo(empresaParaAtualizar, ModelState);

        if (!TryValidateModel(empresaParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(empresaParaAtualizar, empresa);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaEmpresa(int id) 
    {
        var empresa = _context.Empresas.FirstOrDefault(
            empresa => empresa.IdEmpresa == id);
        if (empresa == null) return NotFound();
        _context.Remove(empresa);
        _context.SaveChanges();
        return NoContent();
    }
}