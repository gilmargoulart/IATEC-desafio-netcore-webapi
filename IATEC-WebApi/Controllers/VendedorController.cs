using IATEC_desafio.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace IATEC_desafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        private readonly IATECContext _context;

        public VendedorController(IATECContext context){
            _context = context;
        }

        // GET: api/vendedor
        /// <summary>
        /// Retorna vendedores cadastrados.
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<Vendedor>> GetVendedores()
        {
            // Retorna os vendedores cadastrados
            return _context.Vendedores.ToList();
        }

        // GET: api/vendedor/1
        /// <summary>
        /// Retorna vendedor por ID.
        /// </summary>
        /// <param name="id">Código do vendedor</param>
        [HttpGet("{id}")]
        public ActionResult<Vendedor> GetVendedor(int id)
        {
            Vendedor vendedor = _context.Vendedores.Find(id);

            if (vendedor is null)
            {
                return NotFound();
            }

            return vendedor;
        }


        // PUT: api/vendedor/2
        /// <summary>
        /// Atualiza dados cadastrais do vendedor
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult UpdateVendedor(int id, Vendedor vendedor)
        {
            // id diferente do que tem no Json vendedor
            if (id != vendedor.Id)
            {
                return BadRequest();
            }

            // Buscar o vendedor no BD
            Vendedor v  = _context.Vendedores.Find(id);
            if (v is null)
            {
                // Não encontrado.
                return NotFound();
            }

            // Alterar os dados do vendedor
            v.CPF = vendedor.CPF;
            v.Nome = vendedor.Nome;

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

        // POST: api/vendedor
        /// <summary>
        /// Insere um vendedor
        /// </summary>
        [HttpPost]
        public ActionResult<Vendedor> PostVendedor(VendedorDTO vendedor)
        {
            Vendedor v = new Vendedor() {
                Nome = vendedor.Nome,
                CPF = vendedor.CPF

            };
            _context.Vendedores.Add(v);
            _context.SaveChanges();

            // 201 Created
            return CreatedAtAction(nameof(GetVendedor), new { id = v.Id }, v);
        }
        
        /// <summary>
        /// Deleta vendedor específico
        /// </summary>
        /// <param name="id">Código do vendedor</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Vendedor vendedor = _context.Vendedores.Find(id);

            if (vendedor is null)
            {
                // 404 - código informado não existe
                return NotFound();
            }

            _context.Vendedores.Remove(vendedor);
            _context.SaveChanges();

            return StatusCode(StatusCodes.Status200OK, vendedor);
            
        }
    }
}