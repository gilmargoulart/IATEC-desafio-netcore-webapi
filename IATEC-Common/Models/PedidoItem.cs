using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IATEC_desafio.Common.Contracts;

namespace IATEC_desafio.Common.Models
{
    public class PedidoItem : DefaultEntity
    {
        public int Id { get; set; }
        
        public string CodigoProduto { get; set; }

        public string DescricaoProduto { get; set; }

        public decimal Quantidade { get; set; }

        public decimal ValorUnitario { get; set; }

        public decimal ValorTotal { get => Quantidade * ValorUnitario; }
    }
}