namespace ValidationAttributes.Utilities
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Attributes;
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type classType = obj.GetType();

            PropertyInfo[] properties = classType.GetProperties()
                .Where(x => x.CustomAttributes
                .Any(t => t.AttributeType.BaseType == typeof(MyValidationAttribute)))
                .ToArray();

            foreach (var property in properties)
            {
                object value = property.GetValue(obj);

                foreach (CustomAttributeData customAttributes in property.CustomAttributes)
                {
                    Type attributeType = customAttributes.AttributeType;

                    object attrInstance = property.GetCustomAttribute(attributeType);

                    MethodInfo method = attributeType.GetMethods().First(x => x.Name == "IsValid");

                    bool IsValid = (bool)method.Invoke(attrInstance, new object[] { value });

                    if (!IsValid)
                        return false;
                }
            }
            return true;
        }
    }
}
