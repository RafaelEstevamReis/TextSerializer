namespace TextSerializer.Attributes;

using System;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public class IgnoreAttribute : Attribute
{
}
