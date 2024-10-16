using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaSeuManoel.Domain.DTO.Saida
{
    public class Pedido
    {
        public int Id { get; set; }
        public List<CaixaEmbala> Caixas { get; set; } = new();
    }
}
