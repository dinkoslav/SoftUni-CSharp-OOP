using System;

class Test
{
    static void Main()
    {
        Type type = typeof (GenericList<>);
        object[] allAttributes = type.GetCustomAttributes(false);
        foreach (VersionAttribute attribute in allAttributes)
        {
            Console.WriteLine("Version: " + attribute.version);
            Console.WriteLine("Major version: " + attribute.Major);
            Console.WriteLine("Minor version: " + attribute.Minor);
        }
    }
}
