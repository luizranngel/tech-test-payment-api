using Microsoft.AspNetCore.Mvc;
using tech_test.Models;

namespace TrilhaApiDesafio.Controllers;

[ApiController]
[Route("[controller]")]
public class VendaController : ControllerBase
{
    private readonly List<Venda> vendas = new();

    [HttpGet("{id}")]
    public IActionResult ObterPorId(int id)
    {
        return Ok(vendas[id]);
    }

    [HttpPost]
    public IActionResult Criar(Venda venda)
    {
        if (venda.ItensVendidos.Count < 1)
            return BadRequest("A venda precisa possuir pelo menos 1 item.");

        vendas.Add(venda);

        return Ok("Venda adicionada com sucesso!");
        
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(int id, Venda venda)
    {
        if(vendas[id].Status.ToString() == "AguardandoPagamento")
        {
            if (venda.Status.ToString() == "PagamentoAprovado" || venda.Status.ToString() == "Cancelada")
                vendas[id] = venda;
        }
        else if(vendas[id].Status.ToString() == "PagamentoAprovado")
        {
            if (venda.Status.ToString() == "EnviadoParaTransportadora" || venda.Status.ToString() == "Cancelada")
                vendas[id] = venda;
        }
        else if(vendas[id].Status.ToString() == "EnviadoParaTransportadora")
        {
            if (venda.Status.ToString() == "Entregue")
                vendas[id] = venda;
        }


        return Ok("Venda atualizada com sucesso!");
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(Venda venda)
    {
        vendas.Remove(venda);

        return Ok("Venda deletada com sucesso!");
    }
}
