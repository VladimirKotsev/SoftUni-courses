namespace WarCroft.Entities.Characters
{
    using System;

    using Constants;
    using Contracts;
    using WarCroft.Entities.Inventory;

    public class Warrior : Character, IAttacker
    {
        private const double BaseHeaalthWarrior = 100;
        private const double BaseArmourWarrior = 50;
        private const double WarriorAbilityPoints = 50;
        private const IBag WarriorItem = new Satchel();

        public Warrior(string name) 
            : base(name, BaseHeaalthWarrior, BaseArmourWarrior, WarriorAbilityPoints, WarriorItem)
        {
            this.BaseHealth = BaseHeaalthWarrior;
            this.BaseArmour = BaseArmourWarrior;
        }

        public void Attack(Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                if (this.Name == character.Name)
                {
                    throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
                }

                character.TakeDamage(this.AbilityPoints);
            }
        }
    }
}
