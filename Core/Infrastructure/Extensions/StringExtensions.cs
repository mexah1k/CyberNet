namespace Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static bool ContainsWithNull(this string source, string target)
        {
            // Always return true if compare with null
            return string.IsNullOrEmpty(target) || source.ToLower().Contains(target.ToLower());
        }
    }
}