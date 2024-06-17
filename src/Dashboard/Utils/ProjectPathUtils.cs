namespace JMZ.Dashboard.Utils;

public static class ProjectPathUtils
{
    public static string CurrentPath()
    {
        return ChefAdventure();
    }

    private static string ChefAdventure()
    {
        return @"Z:/dev/gaming/ca/chef-adventure/data";
    }

    private static string TestProject()
    {
        return @"Z:/dev/gaming/rmmz-plugins/project/data";
    }
}