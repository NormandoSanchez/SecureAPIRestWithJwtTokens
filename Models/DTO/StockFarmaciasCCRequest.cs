using System.ComponentModel.DataAnnotations;

namespace SecureAPIRestWithJwtTokens.Models.DTO
{
    /// <summary>
    /// Modelo de solicitud para consultar stock de farmacias Click &amp; Collect
    /// </summary>
    public class StockFarmaciaCCRequest : IValidatableObject
    {
        /// <summary>
        /// Lista de códigos de artículos separados por |
        /// Códigos de artículos son 6 dígitos.
        /// </summary>
        /// <example>000001|000002|000003</example>
        [Required(ErrorMessage = "La lista de artículos es obligatoria")]
        [RegularExpression(@"^[0-9]{6}((\|[0-9]{6})*)$",
            ErrorMessage = "Los artículos deben estar separados por | y cada código debe tener exactamente 6 dígitos")]
        [MaxLength(69, ErrorMessage = "La lista de artículos no puede exceder de 69 posiciones")]
        public string Arts { get; set; } = string.Empty;

        /// <summary>
        /// Lista de unidades de stock mínimas separadas por |
        /// </summary>
        /// <example>1|2|5</example>
        [Required(ErrorMessage = "La lista de unidades es obligatoria")]
        [RegularExpression(@"^[0-9]+((\|[0-9]+)*)$",
            ErrorMessage = "Las unidades deben estar separadas por | y contener solo números")]
        [MaxLength(49, ErrorMessage = "La lista de unidades no puede exceder de 49 posiciones")]
        public string Uds { get; set; } = string.Empty;

        /// <summary>
        /// Identificador de farmacia (0000 para todas las farmacias)
        /// Los identificadores de farmacia son códigos de 4 dígitos.
        /// </summary>
        /// <example>0003</example>
        [Required(ErrorMessage = "El identificador de farmacia inicial es obligatorio")]
        [RegularExpression(@"^[0-9]{4}$",
            ErrorMessage = "El identificador de farmacia debe ser un código de 4 dígitos")]
        public string FarmaIni { get; set; } = string.Empty;

        /// <summary>
        /// Valida que el número de artículos coincida con el número de unidades stock mínimas.
        /// </summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var articulosCount = Arts.Split('|', StringSplitOptions.RemoveEmptyEntries).Length;
            var unidadesArray = Uds.Split('|', StringSplitOptions.RemoveEmptyEntries);

            if (articulosCount != unidadesArray.Length)
            {
#pragma warning disable IDE0300 // Simplificar la inicialización de la recopilación
                yield return new ValidationResult(
                    $"El número de artículos ({articulosCount}) debe coincidir con el número de unidades stock mínimas ({unidadesArray.Length})",
                    new[] { nameof(Arts), nameof(Uds) });
#pragma warning restore IDE0300 // Simplificar la inicialización de la recopilación
            }

            if (articulosCount == 0)
            {
#pragma warning disable IDE0300 // Simplificar la inicialización de la recopilación
                yield return new ValidationResult(
                    "Debe proporcionar al menos un artículo",
                    new[] { nameof(Arts) });
#pragma warning restore IDE0300 // Simplificar la inicialización de la recopilación
            }

            if (articulosCount > 10)
            {
#pragma warning disable IDE0300 // Simplificar la inicialización de la recopilación
                yield return new ValidationResult(
                    "No se pueden consultar más de 10 artículos a la vez",
                    new[] { nameof(Arts) });
#pragma warning restore IDE0300 // Simplificar la inicialización de la recopilación
            }

            // Validar que todas las unidades sean números positivos
            foreach (var unidad in unidadesArray)
            {
                if (!int.TryParse(unidad, out var num) || num <= 0)
                {
#pragma warning disable IDE0300 // Simplificar la inicialización de la recopilación
                    yield return new ValidationResult(
                        $"Las unidades de stock '{unidad}' no son válidas. Deben ser números mayores a 0",
                        new[] { nameof(Uds) });
#pragma warning restore IDE0300 // Simplificar la inicialización de la recopilación
                    break; // Solo reportar el primer error
                }
            }
        }
    }
}