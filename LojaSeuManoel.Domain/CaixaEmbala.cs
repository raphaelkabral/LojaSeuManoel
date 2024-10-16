using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaSeuManoel.Domain
{
    public class CaixaEmbala
    {
        public int Id { get; set; }  
        public int CaixaId { get; set; }
        public Caixa Caixa { get; set; }

        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        public List<Produto> Produtos { get; set; } = new List<Produto>();
    }
}
