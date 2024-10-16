using LojaSeuManoel.Application.IService;
using LojaSeuManoel.Domain.DTO.Entrada;
using Microsoft.AspNetCore.Mvc;

namespace LojaSeuManoel.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;
        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarPedido([FromBody] List<Pedido> pedido)
        {
            var pedidoCriado = await _pedidoService.ProcessarPedidoAsync(pedido);
            return Ok(pedidoCriado);
        }
    }
}
