using System;
using IATEC_desafio.Common.Models;

namespace IATEC_desafio.Common.Utils
{
    public static class CheckPedidoStatus
    {
        private static List<StatusPedidoMock> _statusList = new StatusPedidoMock().BuildStatuses();

        public static bool Check(StatusPedidoEnum status, StatusPedidoEnum newStatus)
        {
            StatusPedidoMock findStatus = _statusList.Find(s => s.Status == status);
            
            if (findStatus is null)
            {
                // Não existe o status na lsita
                return false;
            }

            if (findStatus.Allowed is null)
            {
                // Não existem status que permite migrar
                return false;
            }

            // Verificar se o novo status está na lista
            if (findStatus.Allowed.Any(s => s == newStatus))
            {
                // Permite alteração de status
                return true;
            }

            // Não existe na lista
            return false;
        }

    }

    class StatusPedidoMock {
        public StatusPedidoEnum Status { get; set; }

        public List<StatusPedidoEnum> Allowed { get; set; }

        public StatusPedidoMock(){
            Allowed = new List<StatusPedidoEnum>();
        }

        public List<StatusPedidoMock> BuildStatuses(){
            List<StatusPedidoMock> result = new List<StatusPedidoMock>();

            // Aguardando pagamento
            result.Add(
                new StatusPedidoMock()
                {
                    Status = StatusPedidoEnum.AguardandoPagamento,
                    Allowed = new List<StatusPedidoEnum>() {
                        StatusPedidoEnum.PagamentoAprovado,
                        StatusPedidoEnum.Cancelado}
                }
            );

            // Pagamento aprovado
            result.Add(
                new StatusPedidoMock()
                {
                    Status = StatusPedidoEnum.PagamentoAprovado,
                    Allowed = new List<StatusPedidoEnum>() {
                        StatusPedidoEnum.Enviado,
                        StatusPedidoEnum.Cancelado}
                }
            );

            // Enviado
            result.Add(
                new StatusPedidoMock()
                {
                    Status = StatusPedidoEnum.Enviado,
                    Allowed = new List<StatusPedidoEnum>() {
                        StatusPedidoEnum.Entregue}
                }
            );

            // Entregue
            result.Add(
                new StatusPedidoMock()
                {
                    Status = StatusPedidoEnum.Entregue,
                    Allowed = null
                }
            );

            // Cancelado
            result.Add(
                new StatusPedidoMock()
                {
                    Status = StatusPedidoEnum.Cancelado,
                    Allowed = null
                }
            );

            return result;
        }
    }
}