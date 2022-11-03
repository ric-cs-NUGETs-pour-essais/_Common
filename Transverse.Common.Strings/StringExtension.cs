namespace Transverse.Common.Strings
{
    public static class StringExtension
    {
        public static string EndsWith_(this string string_, bool mustEndWith, string end)
        {
            var retour = string_;
            var endsWith = string_.EndsWith(end);

            if (!endsWith && mustEndWith)
            {
                retour += end;
            }

            else if (endsWith && !mustEndWith)
            {
                retour = retour.Substring(0, retour.Length - end.Length);
            }

            return (retour);
        }

        public static string StartsWith_(this string string_, bool mustStartWith, string start)
        {
            var retour = string_;
            var startsWith = string_.StartsWith(start);

            if (!startsWith && mustStartWith)
            {
                retour = start + retour;
            }

            else if (startsWith && !mustStartWith)
            {
                retour = retour.Substring(start.Length);
            }

            return (retour);
        }

        public static string Substring_(this string string_, int startIndex, int length)
        {
            var retour = (startIndex >= string_.Length) ? string.Empty : string_.Substring(startIndex, length);
            return (retour);
        }
        public static string Substring_(this string string_, int startIndex)
        {
            var retour = (startIndex >= string_.Length) ? string.Empty : string_.Substring(startIndex);
            return (retour);
        }
    }
}