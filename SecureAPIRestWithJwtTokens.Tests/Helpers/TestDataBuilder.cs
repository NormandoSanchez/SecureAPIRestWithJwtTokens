using SecureAPIRestWithJwtTokens.Models.DTO;
using SecureAPIRestWithJwtTokens.Models.Entities;

namespace SecureAPIRestWithJwtTokens.Tests.Helpers;

public static class TestDataBuilder
{
    public static Usuario CreateUser(
        int id = 1,
        string login = "testuser",
        string password = "encryptedPassword",
        bool enabled = true,
        PerfilAcceso? profile = null)
    {
        var assignedProfile = profile ?? CreateProfile();
        var user = new Usuario
        {
            UsrId = id,
            UsrLogin = login,
            UsrPassword = password,
            UsrNombre = $"Usuario {id}",
            UsrHabilitado = enabled,
            UsrAdmin = false,
            PeaId = assignedProfile.PeaId,
            UsrFalta = DateTime.UtcNow.AddDays(-1),
            UsrUalta = 1,
            UsrCambiarLogin = false,
            UsrFirmaPedidos = false,
            UsrGestorPartners = false,
            Perfil = assignedProfile
        };

        assignedProfile.Usuarios.Add(user);
        return user;
    }

    public static PerfilAcceso CreateProfile(int id = 1, string name = "Perfil Test")
    {
        return new PerfilAcceso
        {
            PeaId = id,
            PeaNombre = name,
            PeaFalta = DateTime.UtcNow.AddDays(-10),
            PeaUalta = 1
        };
    }

    public static UsuarioJwtRefresh CreateRefreshToken(
        int userId = 1,
        string userLogin = "testuser",
        string token = "refresh-token",
        DateTime? expiry = null)
    {
        return new UsuarioJwtRefresh
        {
            UsrId = userId,
            UsrLogin = userLogin,
            RefreshToken = token,
            ExpiryDate = expiry ?? DateTime.UtcNow.AddDays(7)
        };
    }

    public static Proceso CreateProcess(
        string id = "MOD00000",
        string name = "Proceso Test",
        bool isModule = false,
        bool? visibleWeb = true)
    {
        return new Proceso
        {
            ProId = id,
            ProNombre = name,
            ProEsModulo = isModule,
            ProDescripcion = "Descripción",
            ProFarmacia = false,
            ProDialog = false,
            ProNivel = 1,
            ProArea = "Area",
            ProAccion = "Index",
            ProController = "Proceso",
            ProImagen = null,
            ProVisibleWeb = visibleWeb,
            ProIconClass = "icon"
        };
    }

    public static LoginApiRequest CreateLoginRequest(
        string userName = "testuser",
        string password = "encryptedPassword")
    {
        return new LoginApiRequest
        {
            UserName = userName,
            EncryptedPassword = password
        };
    }

    public static Empleado CreateEmployee(int id = 1, bool includeBusinessUnit = true, int businessUnitId = 1)
    {
        var employee = new Empleado
        {
            EmpId = id,
            EmpNombre = $"Empleado {id}",
            EmpApellido1 = "Apellido",
            EmpApellido2 = null,
            EmpIdfiscal = $"ID{id}",
            EmpEstado = 1,
            EmpUsrId = null,
            EmpFalta = DateTime.UtcNow.AddDays(-30),
            EmpUalta = 1
        };

        if (includeBusinessUnit)
        {
            var businessUnit = CreateBusinessUnit(businessUnitId);
            var businessUnitDb = CreateBusinessUnitDatabase(businessUnitId);
            businessUnit.UnidadNegocioDb = businessUnitDb;
            businessUnitDb.UnidadNegocio = businessUnit;

            var link = new EmpleadoUnidadNegocio
            {
                EmpId = id,
                UnnId = businessUnit.UnnId,
                UnnUltima = true,
                Empleado = employee,
                UnidadNegocio = businessUnit
            };

            employee.EmpleadosUnidadesNegs.Add(link);
            businessUnit.EmpleadoUnidadesNegocio.Add(link);
        }

        return employee;
    }

    private static UnidadNegocio CreateBusinessUnit(int id)
    {
        return new UnidadNegocio
        {
            UnnId = id,
            UnnTrebol = $"UNN{id}",
            UnnNombre = $"Unidad {id}",
            UnnActiva = true,
            UnnEsCentral = false,
            UnnEsAlmacen = false,
            UnnEsAlmacenTrebol = false,
            UnnFarmatic = false,
            UnnModeloDual = false,
            UnnCanonTrebol = false,
            UnnFincTrebol = DateTime.UtcNow.AddYears(-1),
            UnnFalta = DateTime.UtcNow.AddYears(-2),
            UnnUalta = 1
        };
    }

    private static UnidadNegocioDb CreateBusinessUnitDatabase(int id)
    {
        return new UnidadNegocioDb
        {
            UnnId = id,
            UnnDbserver = "localhost",
            UnnDbuser = "dbuser",
            UnnDbname = "treboldb"
        };
    }

    public static Pais CreatePais(int id = 1, string nombre = "España")
    {
        return new Pais
        {
            PaiId = id,
            PaiNombre = nombre
        };
    }

    public static ComunidadAut CreateComunidadAut(int id = 1, string nombre = "Madrid", int paisId = 1, Pais? pais = null)
    {
        var assignedPais = pais ?? CreatePais(paisId);
        return new ComunidadAut
        {
            CauId = id,
            CauNombre = nombre,
            PaiId = paisId,
            CauExencionIva = false,
            CauConsejo = null,
            Pais = assignedPais
        };
    }

    public static Provincia CreateProvincia(int id = 1, string nombre = "Madrid", int comunidadAutId = 1, int paisId = 1, ComunidadAut? comunidadAut = null)
    {
        var assignedComunidadAut = comunidadAut ?? CreateComunidadAut(comunidadAutId, nombre, paisId);
        return new Provincia
        {
            PrvId = id,
            PrvNombre = nombre,
            CauId = comunidadAutId,
            PaiId = paisId,
            ComunidadAutonoma = assignedComunidadAut
        };
    }

    public static Poblacion CreatePoblacion(int id = 1, string nombre = "Madrid", int provinciaId = 1, int paisId = 1, Provincia? provincia = null)
    {
        var assignedProvincia = provincia ?? CreateProvincia(provinciaId, nombre, 1, paisId);
        return new Poblacion
        {
            PobId = id,
            PobNombre = nombre,
            PrvId = provinciaId,
            PaiId = paisId,
            Provincia = assignedProvincia
        };
    }
}
