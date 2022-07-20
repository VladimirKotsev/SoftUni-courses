namespace WildFarm.Factory.Intefaces
{
    using Models.Animals;
    public interface IFactoryAnimal
    {
        Animal CreateAnimal
            (string type, string name, double weight, params string[] leftovers);
    }
}
