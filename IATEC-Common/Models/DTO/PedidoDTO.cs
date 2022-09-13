namespace IATEC_desafio.Common.Models
{
    public class PedidoDTO
    {
        public int IdVendedor { get; set; }

        public List<PedidoItemDTO> Itens { get; set; }

        public PedidoDTO(){
            Itens = new List<PedidoItemDTO>();
        }
    }
}