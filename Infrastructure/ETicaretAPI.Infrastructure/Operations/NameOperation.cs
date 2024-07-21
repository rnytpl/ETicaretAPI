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
                    case "Ö":
                    case "ö": return "o";
                    case "Ü":
                    case "ü": return "u";
                    case "ı":
                    case "İ": return "i";
                    case "ğ":
                    case "Ğ": return "g";
                    case "â": return "a";
                    case "î": return "i";
                    case "ş":
                    case "Ş": return "s";
                    case "Ç": 
                    case "ç": return "c";
                    case ".": return "-";
                    case " ": return "-";
                    default: return "";
                }
            });

            return name;
        }
    }
    
}
