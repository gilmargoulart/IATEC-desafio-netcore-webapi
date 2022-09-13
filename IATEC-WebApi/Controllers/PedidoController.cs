using IATEC_desafio.Common.Models;
using IATEC_desafio.Common.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace IATEC_desafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IATECContext _context;

        public PedidoController(IATECContext context){
            _context = context;
        }

        // GET: api/pedido/1
        /// <summary>
        /// Retorna pedido por ID.
        /// </summary>
        /// <param name="id">Código do pedido</param>
        [HttpGet("{id}")]
        public ActionResult<Pedido> GetPedido(int id)
        {
            /*
            Pedido pedido = from p
                in _context.Pedidos
                join vend in _context.Vendedores
                    on p.Vendedor.Id equals vend.Id
            */

            ///*
            Pedido pedido = _context.Pedidos
            .Include(p => p.Vendedor)
            .Include(p => p.Itens)
            .Where(pedido => pedido.Id == id)
            .FirstOrDefault();
            //*/
            //Pedido pedido = null;

            if (pedido is null)
            {
                return NotFound(
                    new{ error = $"Pedido '{id}' não existe."});
            }

            return pedido;
        }

        // POST: api/pedido
        /// <summary>
        /// Insere um novo pedido
        /// </summary>
        [HttpPost]
        public ActionResult<Pedido> PostPedido(PedidoDTO pedidoDTO)
        {
            
            Vendedor vendedor = _context.Find<Vendedor>(pedidoDTO.IdVendedor);

            if (vendedor is null)
            {
                return BadRequest(
                    new {error = $"Vendedor '{pedidoDTO.IdVendedor}' não encontrado."}
                );
            }

            // instancia novo pedido a partir do DTO
            Pedido pedido = PedidoFromDTO(pedidoDTO, vendedor);
           
            // Verificar se tem itens no pedido
            if (!pedido.Itens.Any())
            {
                // Pedido deve ter ao menos um item
                return BadRequest(
                    new {error="Pedido deve ter ao menos um item."}
                );
            }
            
            // Inserir o pedido
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            // 201 Created - retorna os dados do pedido criado.
            return CreatedAtAction(nameof(GetPedido), new { id =  pedido.Id}, pedido);
        }

        // PUT: api/pedido/2
        /// <summary>
        /// Atualiza status do pedido
        /// </summary>
        [HttpPut("{id},{statusPedido}")]
        public IActionResult UpdateStatusPedido(int id, StatusPedidoEnum statusPedido)
        {
            
            // Buscar o vendedor no BD
            Pedido pedido  = _context.Pedidos.Find(id);
            if (pedido is null)
            {
                // Não encontrado.
                return NotFound(
                    new { error = $"Pedido '{id}' não existe." }
                );
            }

            // Verificar se a alteração de status é válida.
            if (CheckPedidoStatus.Check(pedido.StatusPedido, statusPedido)){
                return BadRequest(
                    new { error = "Alteração de status não permitida." }
                );
            }

            // alterar o status
            pedido.StatusPedido = statusPedido;

            try
            {
                // Salvar
                _context.SaveChanges();
            }
            //catch (Exception e)
            catch (Exception)
            {
                // Log exception
                return NotFound();
            }

            return StatusCode(StatusCodes.Status200OK);
        }

        private Pedido PedidoFromDTO(PedidoDTO pedidoDTO, Vendedor vendedor){
            
            // Instancia novo pedido
            Pedido pedido = new Pedido() {
                DataHora = DateTime.Now,
                StatusPedido = StatusPedidoEnum.AguardandoPagamento,
                Vendedor = vendedor
            };
            
            if (pedidoDTO.Itens.Any())
            {
                // Adiciona os itens no pedido.
                foreach (PedidoItemDTO item in pedidoDTO.Itens)
                {
                    pedido.Itens.Add(
                        new PedidoItem() {
                            CodigoProduto = item.CodigoProduto,
                            DescricaoProduto = item.DescricaoProduto,
                            Quantidade = item.Quantidade,
                            ValorUnitario = item.ValorUnitario
                        }
                    );
                }
            
            }

            return pedido;
        }
    }
}