using System.Reflection;

namespace DVSClient.Common
{
    public static class EnumExtensions
    {
        public static TEnum? GetEnumValueFromJsonName<TEnum>(this string stringValue) where TEnum : struct
        {
            var type = typeof(TEnum);
            foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                var attribute = field.GetCustomAttribute<EnumStringValueAttribute>();
                if (attribute != null && attribute.JsonName.Equals(stringValue, StringComparison.OrdinalIgnoreCase))
                {
                    return (TEnum?)field.GetValue(null);
                }
            }
            return null;
        }

        public static string? GetJsonNameFromEnum<TEnum>(this TEnum @enum) where TEnum : struct
        {
            var enumString = @enum.ToString();
            if (!string.IsNullOrWhiteSpace(enumString))
            {
                FieldInfo? field = @enum.GetType().GetField(enumString);
                EnumStringValueAttribute? attribute = field?.GetCustomAttribute<EnumStringValueAttribute>();

                return attribute?.JsonName;
            }

            return null;
        }

        public static IEnumerable<string?> GetAllJsonNamesFromEnum<T>() where T : Enum
        {
            return typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static)
                            .Select(field => field.GetCustomAttribute<EnumStringValueAttribute>()?.JsonName)
                            .Where(value => value != null);
        }

        public static IList<T?> GetAllEnumValues<T>() where T : Enum
        {
            return new List<T?>((T[])Enum.GetValues(typeof(T)));
        }
    }
}