namespace Raiding.Factory.Intefaces
{
    using Raiding.Models;
    public interface IFactory
    {
        BaseHero CreateClass(string type, string name);
    }
}
