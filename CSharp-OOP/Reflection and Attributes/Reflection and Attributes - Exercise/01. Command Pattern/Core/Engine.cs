﻿namespace CommandPattern.Core
{
    using System;

    using Contracts;
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            Console.WriteLine(commandInterpreter.Read(Console.ReadLine()));
        }
    }
}
