using IATEC_desafio.Common.Contracts;

namespace IATEC_desafio.Common.Models
{
    ///<summary>
    /// Entidade Pedido
    ///</summary>
    public class Pedido : DefaultEntity
    {

        ///<summary>
        /// Código do pedido.
        ///</summary>
        public int Id { get; set; }

        ///<summary>
        /// Data e hora de criação do pedido.
        ///</summary>
        public DateTime DataHora { get; set; }

        ///<summary>
        /// Vendedor
        ///</summary>
        public Vendedor Vendedor { get; set; }

        ///<summary>
        /// Status do pedido.
        ///</summary>
        public StatusPedidoEnum StatusPedido { get; set; }

        ///<summary>
        /// Itens do pedido.
        ///</summary>
        public List<PedidoItem> Itens { get; set; }

        public Pedido(){
            this.Itens = new List<PedidoItem>();
        }
    }
}
