using System;

namespace PinguApps.Appwrite.Shared.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class SdkExcludeAttribute : Attribute
{
}
