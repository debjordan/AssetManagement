using AssetManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class CategoriaDefeitoController : ControllerBase
{
    private readonly ICategoriaDefeitoRepository _categoriaDefeitoRepository;

    public CategoriaDefeitoController(ICategoriaDefeitoRepository categoriaDefeitoRepository)
    {
        _categoriaDefeitoRepository = categoriaDefeitoRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoriaDefeito>> GetCategoria(Guid id)
    {
        var categoria = await _categoriaDefeitoRepository.GetCategoriaByIdAsync(id);
        if (categoria == null) return NotFound();
        return Ok(categoria);
    }   

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoriaDefeito>>> GetAllCategorias()
    {
        var categorias = await _categoriaDefeitoRepository.GetAllCategoriasAsync();
        return Ok(categorias);
    }
}
