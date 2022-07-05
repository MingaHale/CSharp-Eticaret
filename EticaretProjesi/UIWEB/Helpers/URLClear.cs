namespace UIWEB.Helpers
{
    public static class URLClear
    {
        public static string Temizle(string Data)
        {
            return Data.ToLower().Replace("ç","c").Replace("ü", "u").Replace("ğ", "g").Replace("ş", "s").Replace("ı", "i").Replace("ö", "o").Replace("?", "-").Replace("'", "").Replace("+", "-").Replace("/", "-").Replace("*", "-").Replace("%", "-").Replace("!", "").Replace(".", "").Replace(",", "").Replace(";", "").Replace("=", "").Replace("&", "").Replace(" ", "");
        }
    }
}
