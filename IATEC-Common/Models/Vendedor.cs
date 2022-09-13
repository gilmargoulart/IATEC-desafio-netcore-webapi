using IATEC_desafio.Common.Contracts;

namespace IATEC_desafio.Common.Models
{
    ///<summary>
    /// Entidade Vendedor
    ///</summary>
    public class Vendedor : DefaultEntity
    {
        ///<summary>
        /// Código identificador do vendedor
        ///</summary>
        public int Id { get; set; }

        ///<summary>
        /// Nome do vendedor
        ///</summary>
        public string Nome { get; set; }

        ///<summary>
        /// CPF do vendedor
        ///</summary>
        public string CPF { get; set; }
    }
}