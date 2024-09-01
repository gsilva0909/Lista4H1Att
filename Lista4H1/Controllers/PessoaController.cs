using Lista4H1.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class PessoaController : ControllerBase
{
    private static List<Pessoa> pessoas = new List<Pessoa>();

    [HttpPost("adicionar")]
    public IActionResult AdicionarPessoa([FromBody] Pessoa pessoa)
    {
        pessoas.Add(pessoa);
        return Ok("Pessoa adicionada com sucesso!");
    }

    [HttpPut("atualizar/{cpf}")]
    public IActionResult AtualizarPessoa(string cpf, [FromBody] Pessoa pessoaAtualizada)
    {
        var pessoa = pessoas.FirstOrDefault(p => p.Cpf == cpf);
        if (pessoa == null)
        {
            return NotFound("Pessoa não encontrada.");
        }

        pessoa.Nome = pessoaAtualizada.Nome;
        pessoa.Peso = pessoaAtualizada.Peso;
        pessoa.Altura = pessoaAtualizada.Altura;
        return Ok("Pessoa atualizada com sucesso!");
    }

    [HttpDelete("remover/{cpf}")]
    public IActionResult RemoverPessoa(string cpf)
    {
        var pessoa = pessoas.FirstOrDefault(p => p.Cpf == cpf);
        if (pessoa == null)
        {
            return NotFound("Pessoa não encontrada.");
        }

        pessoas.Remove(pessoa);
        return Ok("Pessoa removida com sucesso!");
    }

    [HttpGet("listar")]
    public IActionResult ListarPessoas()
    {
        if (pessoas.Count == 0)
        {
            return NotFound("Nenhuma pessoa cadastrada.");
        }
        return Ok(pessoas);
    }

    [HttpGet("buscar/{cpf}")]
    public IActionResult BuscarPessoa(string cpf)
    {
        var pessoa = pessoas.FirstOrDefault(p => p.Cpf == cpf);
        if (pessoa == null)
        {
            return NotFound("Pessoa não encontrada.");
        }

        return Ok(pessoa);
    }

    [HttpGet("imc-bom")]
    public IActionResult BuscarPessoasComIMCBom()
    {
        var pessoasComIMCBom = pessoas.Where(p => p.CalcularIMC() >= 18 && p.CalcularIMC() <= 24).ToList();
        if (pessoasComIMCBom.Count == 0)
        {
            return NotFound("Nenhuma pessoa com IMC bom encontrada.");
        }
        return Ok(pessoasComIMCBom);
    }

    [HttpGet("buscar-nome/{nome}")]
    public IActionResult BuscarPessoaPorNome(string nome)
    {
        var pessoasEncontradas = pessoas.Where(p => p.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase)).ToList();
        if (pessoasEncontradas.Count == 0)
        {
            return NotFound("Nenhuma pessoa encontrada com o nome informado.");
        }
        return Ok(pessoasEncontradas);
    }
}
