using LojaSeuManoel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaSeuManoel.Application.IService
{
    public interface IPedidoService
    {
        Task<Pedido> AddPedidoAsync(Pedido pedido);
        Task<List<Caixa>> GetCaixasAsync();
        Task<List<Domain.DTO.Saida.SaidaPedido>> ProcessarPedidoAsync(List<Domain.DTO.Entrada.EntradaPedido> pedido);
    }
}
