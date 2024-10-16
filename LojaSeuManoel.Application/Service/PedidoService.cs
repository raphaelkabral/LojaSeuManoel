using LojaSeuManoel.Application.IService;
using LojaSeuManoel.Domain;
using LojaSeuManoel.Domain.IRepository;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace LojaSeuManoel.Application.Service
{
    public class PedidoService : IPedidoService
    {
        private readonly ICaixaRepository _caixaRepository;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository, ICaixaRepository caixaRepository)
        {
            _caixaRepository = caixaRepository;
            _pedidoRepository = pedidoRepository;
        }
        public async Task<Pedido> AddPedidoAsync(Pedido pedido)
        {
            await _pedidoRepository.AddAsync(pedido);
            return pedido;
        }

        public async Task<List<Caixa>> GetCaixasAsync()
        {
            return (List<Caixa>)await _pedidoRepository.GetAllAsync();
        }

        public async Task<List<Domain.DTO.Saida.Pedido>> ProcessarPedidoAsync(List<Domain.DTO.Entrada.Pedido> pedido)
        {
            List<Domain.DTO.Saida.Pedido> resultado = new();
            foreach (var item in pedido)
            {
                var embalagens = await EmbalarProdutos(item.Produtos);
                Pedido pedidoBd = new Pedido();
                pedidoBd.Id = item.Id;
                pedidoBd.Produtos = item.Produtos;
                await _pedidoRepository.AddAsync(pedidoBd);

                foreach (var r in resultado)
                {
                    r.Id = item.Id;
                    r.Caixas = embalagens;
                }

            }            
            return resultado;
        }

        private async Task<List<CaixaEmbala>> EmbalarProdutos(List<Produto> produtos)
        {
            List<Caixa> caixas = ObterCaixasDisponiveis();
            var resultado = new List<CaixaEmbala>();

            foreach (var caixa in caixas)
            {
                var produtosNaCaixa = new List<Produto>();
                decimal volumeCaixa = caixa.Altura * caixa.Largura * caixa.Comprimento;
                decimal volumeUsado = 0;

                foreach (var produto in produtos)
                {
                    decimal volumeProduto = produto.Altura * produto.Largura * produto.Comprimento;
                    if (volumeUsado + volumeProduto <= volumeCaixa)
                    {
                        produtosNaCaixa.Add(produto);
                        volumeUsado += volumeProduto;
                    }
                }

                if (produtosNaCaixa.Count > 0)
                {
                    CaixaEmbala caixaEmbala = new CaixaEmbala();
                    caixaEmbala.Caixa = caixa;
                    caixaEmbala.Produtos= produtosNaCaixa;
                    resultado.Add(caixaEmbala);
                }
            }

            return await Task.FromResult(resultado);
        }

        private List<Caixa> ObterCaixasDisponiveis()
        {
            return new List<Caixa>
        {
            new Caixa { Id = 1 , Nome = "Caixa 1", Altura = 30, Largura = 40, Comprimento = 80 },
            new Caixa { Id = 2 ,Nome = "Caixa 2", Altura = 80, Largura = 50, Comprimento = 40 },
            new Caixa { Id = 3 ,Nome = "Caixa 3", Altura = 50, Largura = 80, Comprimento = 60 }
        };
        }
    }
}
