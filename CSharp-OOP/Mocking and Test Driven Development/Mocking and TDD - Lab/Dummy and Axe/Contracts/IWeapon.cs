namespace Dummy_and_Axe_Tests.Contracts
{
    public interface IWeapon
    {
        int AttackPoints { get; }
        int DurabilityPoints { get; }
        public void Attack(ITarget target);
    }
}
