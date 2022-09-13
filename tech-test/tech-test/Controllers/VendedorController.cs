using Microsoft.AspNetCore.Mvc;
using tech_test.Models;

namespace TrilhaApiDesafio.Controllers;

[ApiController]
[Route("[controller]")]
public class VendedorController : ControllerBase
{
    private  List<Vendedor> vendedors = new();

    [HttpGet("{id}")]
    public IActionResult ObterPorId(int id)
    {
        return Ok(vendedors[id]);
    }

    [HttpPost]
    public IActionResult Criar(Vendedor vendedor)
    {
        vendedors.Add(vendedor);

        return Ok("Vendedor adicionada com sucesso!");
        
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(int id, Vendedor vendedor)
    {
        vendedors[id] = vendedor;

        return Ok("Vendedor atualizada com sucesso!");
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(Vendedor vendedor)
    {
        vendedors.Remove(vendedor);

        return Ok("Vendedor deletada com sucesso!");
    }
}
