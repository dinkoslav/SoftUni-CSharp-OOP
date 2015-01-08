using System;

[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface |
AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = true)]

public class VersionAttribute : System.Attribute
{
    public string version;
    public int Major { get; private set; }
    public int Minor { get; private set; }

    public VersionAttribute(int major, int minor)
    {
        this.Major = major;
        this.Minor = minor;
        this.version = this.Major + "." + this.Minor;
    }
}
