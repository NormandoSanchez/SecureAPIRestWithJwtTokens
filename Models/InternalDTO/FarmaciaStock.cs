namespace SecureAPIRestWithJwtTokens.Models.InternalDTO
{
    public class FarmaciaStock
    {
        public string? IdFarmacia { get; set; }
        public string? Descripcion { get; set; }
        public string? Direccion { get; set; }
        public int IdUnidadNegocioERP { get; set; }
        public string Server { get; set; } = string.Empty;
        public string DataBase { get; set; } = string.Empty;
        public string UsuarioDB { get; set; } = string.Empty;
        public string PasswordDB { get; set; } = string.Empty;
        public string? Stock { get; set; }
    }

    public class StockArticulo(string Id, int Solicitado, int Real)
    {
        public string IdArticulo { get; set; } = Id;
        public int StockSolicitado { get; set; } = Solicitado;
        public int StockReal { get; set; } = Real;
        public bool TieneStock
        {
            get
            {
                return StockReal >= StockSolicitado;
            }
        }
    }
}
