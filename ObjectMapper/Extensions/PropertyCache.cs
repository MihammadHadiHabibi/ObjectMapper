using System.Reflection;

namespace ObjectMapper.Extensions;

public class PropertyCache<T>
{
    /// <summary>
    /// Caches the properties of the specified type T.
    /// This helps in reducing the overhead of using reflection multiple times for the same type.
    /// </summary>
    public static readonly PropertyInfo[] Properties = typeof(T).GetProperties();
}
