namespace DVSClient.Common
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    sealed class EnumStringValueAttribute : Attribute
    {
        public string JsonName { get; }
        public string Description { get; }
        public string Example { get; }

        public EnumStringValueAttribute(string friendlyName)
        {
            JsonName = friendlyName;
            Description = string.Empty;
            Example = string.Empty;
        }

        public EnumStringValueAttribute(string friendlyName, string description)
        {
            JsonName = friendlyName;
            Description = description;
            Example = string.Empty;
        }

        public EnumStringValueAttribute(string friendlyName, string description, string example)
        {
            JsonName = friendlyName;
            Description = description;
            Example = example;
        }
    }
}