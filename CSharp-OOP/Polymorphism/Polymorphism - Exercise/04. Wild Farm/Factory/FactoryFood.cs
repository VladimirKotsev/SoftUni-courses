namespace WildFarm.Factory
{
    using Intefaces;
    using Models.Foods;

    public class FactoryFood : IFactoryFood
    {
        public Food CreateFood(string type, int quantity)
        {
            Food food = null;

            if (type == "Fruit")
                food = new Fruit(quantity);
            else if (type == "Meat")
                food = new Meat(quantity);
            else if (type == "Seeds")
                food = new Seeds(quantity);
            else if (type == "Vegetable")
                food = new Vegetable(quantity);

            return food;

        }
    }
}
