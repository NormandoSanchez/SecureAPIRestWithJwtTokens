using System.ComponentModel.DataAnnotations;

namespace SecureAPIRestWithJwtTokens.Models.DTO
{
    public class IDTOWithValidator<T> where T : class
    {
        /// <summary>
        /// Valida todas las anotaciones de validación del objeto.
        /// </summary>
        /// <param name="validationResults">Lista de resultados de validación con los errores encontrados.</param>
        /// <returns>True si todas las validaciones son correctas, false si hay errores.</returns>
        public bool TryValidate(out ICollection<ValidationResult> validationResults)
        {
            validationResults = [];
            var context = new ValidationContext(this, serviceProvider: null, items: null);

            return Validator.TryValidateObject(this, context, validationResults, validateAllProperties: true);
        }

        /// <summary>
        /// Valida el objeto y lanza una ValidationException si hay errores.
        /// </summary>
        /// <exception cref="ValidationException">Se lanza cuando hay errores de validación.</exception>
        public void Validate()
        {
            var context = new ValidationContext(this, serviceProvider: null, items: null);
            Validator.ValidateObject(this, context, validateAllProperties: true);
        }

        /// <summary>
        /// Obtiene todos los errores de validación como un diccionario.
        /// </summary>
        /// <returns>Diccionario con el nombre de la propiedad y su lista de mensajes de error.</returns>
        public Dictionary<string, string[]> GetValidationErrors()
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(this, serviceProvider: null, items: null);

            Validator.TryValidateObject(this, context, validationResults, validateAllProperties: true);

            return validationResults
                .GroupBy(vr => vr.MemberNames.FirstOrDefault() ?? "General")
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(vr => vr.ErrorMessage ?? "Error de validación").ToArray()
                );
        }
    }
}
