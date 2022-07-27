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

        public string AnalyzeAccessModifiers(string nameOfClass)
        {

            Type type = Type.GetType($"Stealer.{nameOfClass}");

            FieldInfo[] fieldInfos = type.GetFields(
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);

            StringBuilder sb = new StringBuilder();
            
            MethodInfo[] publicMethods = type.GetMethods(
                BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] privateMethods = type.GetMethods(
                BindingFlags.Instance | BindingFlags.NonPublic);

            foreach(var field in fieldInfos)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            foreach(MethodInfo method in publicMethods.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }
            foreach(MethodInfo method in privateMethods.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().Trim();

        }
    }
}
