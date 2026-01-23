using AutoMapper;
using SecureAPIRestWithJwtTokens.Models.Entities;
using System.Text;

namespace SecureAPIRestWithJwtTokens.Mappings
{
    /// <summary>
    /// Mapping profile para Direccion
    /// </summary>
    public class DireccionMappingProfile : Profile
    {
        /// <summary>
        /// Constructor del perfil de mapeo
        /// </summary>
        public DireccionMappingProfile()
        {
            // Mapeo de Direccion a String DireccionCompleta
            CreateMap<Direccion, string>()
                .ConvertUsing(src => CreateDirString(src) ?? string.Empty);
        }

        private static string CreateDirString(Direccion dir)
        {
            StringBuilder sb = new();

            if (dir == null)
                return string.Empty;
            sb.Append(dir.TipoVia == null ? string.Empty : dir.TipoVia.TviNombre.Trim());
            sb.Append(string.Concat(" ", dir.DirNombreCalle.Trim()));
            sb.Append(string.IsNullOrWhiteSpace(dir.DirNumero) ? string.Empty : string.Concat(", ", dir.DirNumero.Trim()));
            sb.Append(string.IsNullOrWhiteSpace(dir.DirPortal) ? string.Empty : string.Concat(" ", dir.DirPortal.Trim()));
            sb.Append(string.IsNullOrWhiteSpace(dir.DirEscalera) ? string.Empty : string.Concat(" ", dir.DirEscalera.Trim()));
            sb.Append(string.IsNullOrWhiteSpace(dir.DirPiso) ? string.Empty : string.Concat(" ", dir.DirPiso.Trim()));
            sb.Append(string.IsNullOrWhiteSpace(dir.DirPuerta) ? string.Empty : string.Concat(" ", dir.DirPuerta.Trim()));
            sb.Append(string.IsNullOrWhiteSpace(dir.DirCodPostal) ? string.Empty : string.Concat(" ", dir.DirCodPostal.Trim()));
            sb.Append(string.Concat(" ", dir.Poblacion?.PobNombre.Trim()));
            sb.Append(string.Concat(" ", dir.Provincia?.PrvNombre.Trim()));

            return sb.ToString().Trim();
        }
    }
}
