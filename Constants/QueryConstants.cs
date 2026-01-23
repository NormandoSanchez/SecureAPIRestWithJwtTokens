namespace SecureAPIRestWithJwtTokens.Constants;

public static class QueryConstants
{
    public const string GET_CENTRALCOMUN_FARMACIAS_CLICK_COLLECT = "SELECT LTRIM(RTRIM(IdFarmacia)) AS IdFarmacia FROM dbo.totalfarmacias WHERE CCollect = 'S'";
    public const string GET_ARTICULOS_FARMACIAS = "SELECT IdArticu, StockActual FROM dbo.Articu WHERE IdArticu IN ({0})";
}
