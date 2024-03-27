using System.Reflection;

namespace SmartEnum.ConsoleApp;
public abstract class Enumeration<TEnum>
    where TEnum : Enumeration<TEnum>
{
    public static readonly Dictionary<string, TEnum> Enumerations = CreateEnumerations();

    protected Enumeration(string value, string name)
    {
        Value = value;
        Name = name;
    }

    public string Value { get; protected set; } = string.Empty;
    public string Name { get; protected set; } = string.Empty;

    public static TEnum? FromValue(string value)
    {
        return Enumerations.TryGetValue(value, out TEnum? enumeration) ? enumeration : null;
    }

    public static TEnum? FromName(string name)
    {
        return Enumerations.Values.SingleOrDefault(e => e.Name == name);
    }

    private static Dictionary<string, TEnum> CreateEnumerations()
    {
        var enumerationType = typeof(TEnum);

        var fieldsForType = enumerationType
            .GetFields(
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.FlattenHierarchy
            )
            .Where(fieldInfo => enumerationType.IsAssignableFrom(fieldInfo.FieldType))
            .Select(fieldInfo => (TEnum)fieldInfo.GetValue(default)!);

            return fieldsForType.ToDictionary(x => x.Value);
    }
}
