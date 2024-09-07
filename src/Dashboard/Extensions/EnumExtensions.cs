using System.ComponentModel;

namespace JMZ.Dashboard.Extensions;

public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
        var fi = value.GetType()
            .GetField(value.ToString());

        if (fi!.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attributes
            && attributes.Any())
        {
            return attributes.First()
                .Description;
        }

        return value.ToString();
    }
}