namespace WildFarm.Factory.Intefaces
{
    using Models.Foods;
    public interface IFactoryFood
    {
        Food CreateFood(string type, int quantity);
    }
}
