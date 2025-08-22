namespace RestfulBooker.Tests.Extensions
{
    public static class TypeNameExtensions
    {
        public static string GetFriendlyName(this Type type)
        {
            if (!type.IsGenericType)
            {
                return type.Name;
            }

            var genericTypeName = type.Name[..type.Name.IndexOf('`')];
            var args = type.GetGenericArguments().Select(GetFriendlyName);
            return $"{genericTypeName}<{string.Join(", ", args)}>";
        }
    }
}