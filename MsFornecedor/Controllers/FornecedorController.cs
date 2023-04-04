using Microsoft.AspNetCore.Mvc;
using MsFornecedor.Dtos;
using MsFornecedor.Repositorys.Entidades;
using MsFornecedor.Services.Interfaces;

namespace MsFornecedor.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly IFornecedorService _fornecedorService;
        public FornecedorController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }
        [HttpPost("/api/AdicionarFornecedor")]
        public async Task<IActionResult> AdicionarFornecedor([FromBody] FornecedorDto fornecedorDto)
        {
            try
            {
                var result = await this._fornecedorService.AddFornecedor(fornecedorDto);

                if (!result) return BadRequest("Ocorreu um erro interno ao adicionar o fornecedor.");

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("/api/EditarFornecedor")]
        public async Task<IActionResult> EditarFornecedor([FromBody] Fornecedor fornecedor)
        {
            try
            {
                var result = await this._fornecedorService.UpdateFornecedor(fornecedor);

                if (!result) return BadRequest("Ocorreu um erro interno ao editar o fornecedor!");

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("/api/RetornaFornecedorPorId/{id:int}")]
        public async Task<IActionResult> RetornaFornecedorPorId(int id)
        {
            try
            {
                var fornecedor = await this._fornecedorService.GetById(id);

                return Ok(fornecedor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("/api/ExcluirFornecedor/{id:int}")]
        public async Task<IActionResult> ExcluirFornecedor(int id)
        {
            try
            {
                var result = await this._fornecedorService.DeleteFornecedor(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("/api/ListaFornecedor")]
        public async Task<IActionResult> ListaFornecedor()
        {
            try
            {
                var fornecedores = await this._fornecedorService.ListaFornecedor();

                return Ok(fornecedores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("/api/ListaPaginacaoFornecedor/{pagina}/{query?}")]
        public async Task<IActionResult> ListaPaginacao(int pagina, string query = "")
        {
            try
            {
                var paginacao = await this._fornecedorService.GetPaginacao(pagina, query);

                if (paginacao == null) return Json(BadRequest());

                return Ok(paginacao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
