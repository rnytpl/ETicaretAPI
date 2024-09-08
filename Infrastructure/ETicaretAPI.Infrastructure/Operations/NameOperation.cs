using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Operations
{
    public static class NameOperation
    {
        public static string CharacterRegulatory(string name)
        {
            // Regex pattern matching all characters to be removed or replaced
            string pattern = @"[""!'^\+%&/()=?_@€¨~,;:ÖöÜüıİğĞæßâîşŞÇç<>|]|\s|\.";

            // Replacement function using regex
            name = Regex.Replace(name, pattern, m =>
            {
                switch (m.Value)
                {
                    case "Ö": return "O";
                    case "ö": return "o";
                    case "Ü":
                    case "ü": return "u";
                    case "ı":
                    case "İ": return "I";
                    case "ğ":
                    case "Ğ": return "G";
                    case "â": return "A";
                    case "î": return "I";
                    case "ş":
                    case "Ş": return "S";
                    case "Ç": return "C";
                    case "ç": return "c";
                    case ".": return "-";
                    case " ": return "-";
                    case "_": return "-";
                    default: return "";
                }
            });

            return name;
        }
    }
    
}
