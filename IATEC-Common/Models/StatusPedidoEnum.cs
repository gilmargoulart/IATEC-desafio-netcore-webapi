namespace IATEC_desafio.Common.Models
{
    /// <summary>
    /// Status de pedido.
    /// 0: Aguardando pagamento
    /// 1: Pagamento aprovado
    /// 2: Enviado
    /// 3: Entregue
    /// 9: Cancelado
    /// </summary>
    public enum StatusPedidoEnum : short
    {
        AguardandoPagamento = 0,

        PagamentoAprovado = 1,
        
        Enviado = 2,
        
        Entregue = 3,
        
        Cancelado = 9
    }

}
