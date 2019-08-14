using System.Globalization;
using System.Text;

namespace RemoveDiacritics
{
    public static class Remover
    {
        public static string RemoveDiacritics(string input)
        {
            var stFormD = input.Normalize(NormalizationForm.FormD);
            var len = stFormD.Length;
            var sb = new StringBuilder();
            for (var j = 0; j < len; j++)
                if (CharUnicodeInfo.GetUnicodeCategory(stFormD[j]) != UnicodeCategory.NonSpacingMark)
                    sb.Append(stFormD[j]);

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
