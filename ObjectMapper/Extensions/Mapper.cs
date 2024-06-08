namespace ObjectMapper.Extensions;

public static class Mapper
{
    /// <summary>
    /// Maps the properties of the source object to a new instance of the destination type.
    /// Only properties with the same name and type are mapped.
    /// </summary>
    /// <typeparam name="TSource">The type of the source object.</typeparam>
    /// <typeparam name="TDestination">The type of the destination object.</typeparam>
    /// <param name="source">The source object to map from.</param>
    /// <returns>A new instance of the destination type with properties mapped from the source object.</returns>
    public static TDestination Map<TSource, TDestination>(TSource source) where TDestination : new()
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        TDestination destination = new();
        var sourceProperties = PropertyCache<TSource>.Properties;
        var destinationProperties = PropertyCache<TDestination>.Properties;

        var destinationPropertiesDict = destinationProperties.ToDictionary(p => p.Name.ToLower(), p => p);

        foreach (var sourceProperty in sourceProperties)
        {
            if (destinationPropertiesDict.TryGetValue(sourceProperty.Name.ToLower(), out var destinationProperty) &&
                destinationProperty.PropertyType == sourceProperty.PropertyType)
            {
                destinationProperty.SetValue(destination, sourceProperty.GetValue(source));
            }
        }

        return destination;
    }


    /// <summary>
    /// Maps a list of source objects to a list of destination objects.
    /// Each source object is mapped to a new instance of the destination type.
    /// </summary>
    /// <typeparam name="TSource">The type of the source objects.</typeparam>
    /// <typeparam name="TDestination">The type of the destination objects.</typeparam>
    /// <param name="sourceList">The list of source objects to map from.</param>
    /// <returns>A list of new instances of the destination type with properties mapped from the source objects.</returns>
    public static List<TDestination> MapList<TSource, TDestination>(List<TSource> sourceList) where TDestination : new()
    {
        if (sourceList == null)
        {
            throw new ArgumentNullException(nameof(sourceList));
        }

        return sourceList.Select(Map<TSource, TDestination>).ToList();
    }
}
