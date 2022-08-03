namespace CommandPattern.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] splitedArgs = args.Split(' ');

            Assembly assembly = Assembly.GetCallingAssembly();
            Type type = assembly.GetTypes().First(x => x.Name.StartsWith(splitedArgs[0]));
            MethodInfo method = type.GetMethod("Execute");

            var activator = Activator.CreateInstance(type);
            string[] parameters = splitedArgs.Skip(1).ToArray();

            return (string)method.Invoke(activator, new object[] { parameters });
        }
    }
}
