﻿using System;
using Dummy_and_Axe_Tests.Contracts;

// Axe durability drop with 5 
public class Axe : IWeapon
{
    private int attackPoints;
    private int durabilityPoints;

    public Axe(int attack, int durability)
    {
        this.attackPoints = attack;
        this.durabilityPoints = durability;
    }

    public int AttackPoints
    {
        get { return this.attackPoints; }
    }

    public int DurabilityPoints
    {
        get { return this.durabilityPoints; }
    }

    public void Attack(Dummy target)
    {
        if (this.durabilityPoints <= 0)
        {
            throw new InvalidOperationException("Axe is broken.");
        }

        target.TakeAttack(this.attackPoints);
        this.durabilityPoints -= 1;
    }

    public void Attack(ITarget target)
    {
        if (durabilityPoints <= 0)
        {
            throw new InvalidOperationException("Axe is broken.");
        }

        target.TakeAttack(attackPoints);
        durabilityPoints -= 1;
    }
}
