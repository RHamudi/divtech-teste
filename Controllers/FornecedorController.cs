using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using divtech_teste.Data;
using divtech_teste.Models;
using divtech_teste.ViewModels.Fornecedores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace divtech_teste.Controllers
{
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        [HttpGet("/fornecedores")]
        public async Task<IActionResult> PegarFornecedores(
            [FromServices] DataContext context
        )
        {
            try
            {
                var Fornecedores = await context.Fornecedores.ToListAsync();
                if(Fornecedores.Count == 0)
                    return StatusCode(400, "Nenhum Fornecedor cadastrado");

                return Ok(Fornecedores);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno - {ex.Message}");
            }
        }

        [HttpPost("/fornecedores")]
        public async Task<IActionResult> CriarFornecedor(
            [FromBody] FornecedoresViewModel model,
            [FromServices] DataContext context
        )
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var forne = new Fornecedores
            {
                Id = 0,
                Nome = model.Nome,
                CNPJ = model.CNPJ,
                Especialidade = model.Especialidade
            };

            try
            {
                if(!forne.Especialidade.Contains("Indústria") && !forne.Especialidade.Contains("Serviço") && !forne.Especialidade.Contains("Comércio"))
                    return StatusCode(400, "Especialidade invalida");

                await context.Fornecedores.AddAsync(forne);
                await context.SaveChangesAsync();
                return Ok(forne);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPatch("fornecedores/{id}")]
        public async Task<IActionResult> AtualizarFornecedor(
            [FromBody] Fornecedores model,
            [FromServices] DataContext context
        )
        {
            if(!ModelState.IsValid)
                return BadRequest();
            
            var forne = await context.Fornecedores.FirstOrDefaultAsync(x => x.Id == model.Id);
            if(forne == null)
                return NotFound();
            
            forne.Nome = model.Nome;
            forne.CNPJ = model.CNPJ;
            forne.Especialidade = model.Especialidade;

            try
            {
                if(!forne.Especialidade.Contains("Indústria") && !forne.Especialidade.Contains("Serviço") && !forne.Especialidade.Contains("Comércio"))
                    return StatusCode(400, "Especialidade invalida");

                context.Fornecedores.Update(forne);
                await context.SaveChangesAsync();

                return Ok("Fornecedor Atualizado");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("fornecedores/{id}")]
        public async Task<IActionResult> DeletarFornecedor(
            [FromRoute] int id,
            [FromServices] DataContext context
        )
        {
            try
            {
                var forne = await context.Fornecedores.FirstOrDefaultAsync(x => x.Id == id);
                if(forne == null)
                    return NotFound();
                
                context.Fornecedores.Remove(forne);
                await context.SaveChangesAsync();

                return Ok("Produto removido com sucesso");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}