using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using divtech_teste.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace divtech_teste.Controllers
{
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        [HttpGet("fornecedores")]
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

        [HttpPost("fornecedores")]
        public async Task<IActionResult> CriarFornecedor(
            
        )
        {

        }
    }
}