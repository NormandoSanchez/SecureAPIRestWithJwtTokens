using System.ComponentModel.DataAnnotations;

namespace SecureAPIRestWithJwtTokens.Models.DTO
{
    /// <summary>
    /// Farmacia C&amp;C que tiene el stock indicado de los articulos indicados 
    /// </summary>
    public class StockFarmaciaDto
    {
        /// <summary>
        /// Identificador de farmacia. Desde BD totalfarmacias  
        /// </summary>
        [Required]
        public string? IdFarmacia { get; set; }

        /// <summary>
        /// Descripcion de farmacia 
        /// </summary>
        [Required]
        public string? Descripcion { get; set; }

        /// <summary>
        /// Direccion TipoVia Nombre Via, nº {{Portal} {Escalera} {Piso} {Puerta}} CodigoPostal Poblacion Provincia 
        /// </summary>
        [Required]
        public string? Direccion { get; set; }

        /// <summary>
        /// Indicador de existencia de Stock. SI/NO 
        /// </summary>
        [Required]
        public string? Stock { get; set; }
    }
}
