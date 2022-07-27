namespace Stealer
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy : ISpy
    {
        public string StealFieldInfo(string nameOfClass, params string[] args)
        {
            Type classType = Type.GetType(nameOfClass);
            FieldInfo[] classFields = classType.GetFields(
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
            StringBuilder sb = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            sb.AppendLine($"Class under investigation: {nameOfClass}");

            foreach (FieldInfo field in classFields.Where(x => args.Contains(x.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
            return sb.ToString().Trim();
        }
    }
}
