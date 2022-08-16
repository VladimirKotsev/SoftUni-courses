namespace Easter.Models.Workshops
{


    using Contracts;
    using Easter.Models.Bunnies.Contracts;
    using Easter.Models.Eggs.Contracts;
    using System.Linq;

    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            while (true)
            {
                if (bunny.Energy == 0 || bunny.Dyes.All(x => x.IsFinished()) || egg.IsDone())
                {
                    break;
                }

                bunny.Work();
                bunny.Dyes.First(x => !x.IsFinished()).Use();
                egg.GetColored();
            }
        }
    }
}
