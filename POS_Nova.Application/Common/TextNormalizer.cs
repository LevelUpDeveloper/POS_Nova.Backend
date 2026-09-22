using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Nova.Application.Common
{
    public class TextNormalizer
    {
        // Removes leading and trailing whitespace and replaces multiple spaces with a single one
        public static string NormalizeSpaces(string cadena)
        {
            if (string.IsNullOrWhiteSpace(cadena))
                return string.Empty;

            return string.Join(
                " ",
                cadena.Trim()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            );
        }

        // Format the name: first letter uppercase and the rest lowercase
        public static string FormatName(string cadena)
        {
            var normalized = NormalizeSpaces(cadena);

            if (string.IsNullOrEmpty(normalized))
                return string.Empty;

            normalized = normalized.ToLowerInvariant();

            return char.ToUpperInvariant(normalized[0]) +
                   normalized[1..];
        }

        // Convert all the text to uppercase
        public static string ToUpperCase(string cadena)
        {
            var normalized = NormalizeSpaces(cadena);

            if (string.IsNullOrEmpty(normalized))
                return string.Empty;

            return normalized.ToUpperInvariant();
        }

        // Convert all the text to lowercase
        public static string ToLowerCase(string cadena)
        {
            var normalized = NormalizeSpaces(cadena);

            if (string.IsNullOrEmpty(normalized))
                return string.Empty;

            return normalized.ToLowerInvariant();
        }

    }
}
