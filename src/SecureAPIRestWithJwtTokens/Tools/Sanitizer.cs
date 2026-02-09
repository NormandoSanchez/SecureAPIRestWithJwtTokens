using System.Globalization;
using System.Text;

namespace SecureAPIRestWithJwtTokens.Tools
{
    /// <summary>
    /// Sanitiza valores potencialmente controlados por usuario antes de enviarlos a logs.
    /// Previene log forging (CR/LF), caracteres de control y spoofing por caracteres de formato.
    /// </summary>
    public static class Sanitizer
    {
        public static string Sanitize(string? value, int maxLength = 128)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }

            if (maxLength <= 0)
            {
                return string.Empty;
            }

            var trimmed = value.Trim();
            var builder = new StringBuilder(Math.Min(trimmed.Length, maxLength));

            foreach (var ch in trimmed)
            {
                var category = char.GetUnicodeCategory(ch);

                if (category == UnicodeCategory.Control ||
                    category == UnicodeCategory.Format ||
                    category == UnicodeCategory.Surrogate ||
                    category == UnicodeCategory.OtherNotAssigned)
                {
                    continue;
                }

                builder.Append(ch);

                if (builder.Length >= maxLength)
                {
                    break;
                }
            }

            return builder.ToString();
        }
    }
}
