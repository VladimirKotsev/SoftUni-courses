namespace Raiding
{
    using System;
    using Core;
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Start();
        }
    }
}
