using System;

namespace POC.Automation.Helpers.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PageAttribute : Attribute
    {
        public string Name { get; set; }

        public PageAttribute(string name)
        {
            Name = name;
        }
    }
}
