namespace SecureAPIRestWithJwtTokens.Models.InternalDTO
{
    /// <summary>
    /// Contiene el resultado de la ejecución de una consulta en un único servidor.
    /// </summary>
    /// <typeparam name="T">El tipo de dato del resultado (DataTable para queries, int para non-queries).</typeparam>
    public class MultiServerQueryResult<T>
    {
        /// <summary>
        /// Identifdicador unico de la unidad de negocio ERP asociada al servidor.
        /// </summary>
        public int IdUnidadNegocioERP { get; set; } 

        /// <summary>
        /// Identificador único del servidor en formato "Servidor/BaseDeDatos".
        /// </summary>
        public string ServerKey { get; set; } = string.Empty;

        /// <summary>
        /// Indica si la operación se completó con éxito.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Los datos devueltos por la operación.
        /// </summary>
        public T? Data { get; set; }

        /// <summary>
        /// Mensaje de error en caso de fallo.
        /// </summary>
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// Tiempo que tardó la operación en este servidor.
        /// </summary>
        public TimeSpan ExecutionTime { get; set; }

        /// <summary>
        /// Marca de tiempo de la ejecución.
        /// </summary>
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }

    /// <summary>
    /// Agrega los resultados de la ejecución en múltiples servidores.
    /// </summary>
    /// <typeparam name="T">El tipo de dato del resultado.</typeparam>
    public class MultiServerExecutionSummary<T>
    {
        /// <summary>
        /// Número total de servidores a los que se intentó conectar.
        /// </summary>
        public int TotalServers { get; set; }

        /// <summary>
        /// Número de operaciones exitosas.
        /// </summary>
        public int SuccessCount { get; set; }

        /// <summary>
        /// Número de operaciones fallidas.
        /// </summary>
        public int FailureCount { get; set; }

        /// <summary>
        /// Número de operaciones rechazadas por el Circuit Breaker (sin intentar conectar).
        /// </summary>
        public int CircuitBreakerRejections { get; set; }

        /// <summary>
        /// Tiempo total que tardó la ejecución de todas las tareas en paralelo.
        /// </summary>
        public TimeSpan TotalExecutionTime { get; set; }

        /// <summary>
        /// Lista de resultados detallados de cada servidor.
        /// </summary>
        public List<MultiServerQueryResult<T>> Results { get; set; } = [];

        /// <summary>
        /// Porcentaje de éxito de las operaciones.
        /// </summary>
        public double SuccessRate => TotalServers > 0
            ? (double)SuccessCount / TotalServers * 100
            : 0;
    }
}