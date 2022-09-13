using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IATEC_desafio.Common.Models
{
    public class PedidoItemDTO
    {
        public string CodigoProduto { get; set; }

        public string DescricaoProduto { get; set; }

        public decimal Quantidade { get; set; }

        public decimal ValorUnitario { get; set; }
    }
}