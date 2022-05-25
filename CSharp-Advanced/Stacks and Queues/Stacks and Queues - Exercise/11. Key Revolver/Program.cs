using System;
using System.Linq;
using System.Collections.Generic;

namespace _11._Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> bullets = new Stack<int>();
            Queue<int> locks = new Queue<int>();
            Queue<int> weapon = new Queue<int>();
            //input
            int priceOfBullet = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            //weapon
            bullets = WeaponFill();
            int bulletCount = bullets.Count;
            if (bullets.Count >= barrelSize)
                for (int i = 1; i <= barrelSize; i++)
                    weapon.Enqueue(bullets.Pop());
            else
                for (int i = 0; i <= bullets.Count; i++)
                    weapon.Enqueue(bullets.Pop());
            //locks
            locks = LockFill();
            int intelPrice = int.Parse(Console.ReadLine());

            //body
            while (locks.Count > 0)
            {
                if (weapon.Peek() <= locks.Peek()) //open a lock
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                    weapon.Dequeue();
                }
                else //not succeded lock
                {
                    Console.WriteLine("Ping!");
                    weapon.Dequeue();
                }
                if (weapon.Count == 0) //reload weapon
                {
                    if (bullets.Count == 0)
                        break;
                    Console.WriteLine("Reloading!");
                    if (bullets.Count >= barrelSize)
                        for (int i = 1; i <= barrelSize; i++)
                            weapon.Enqueue(bullets.Pop());
                    else
                        for (int i = 0; i <= bullets.Count; i++)
                            weapon.Enqueue(bullets.Pop());
                }
            }
            //output
            if (bullets.Count >= 0 && locks.Count == 0)
            {
                //unload weapon
                if (weapon.Count > 0)
                {
                    foreach (var b in weapon)
                        bullets.Push(b);
                }
                PrintOutSucces(bullets, bulletCount, priceOfBullet, intelPrice);
            }
            else if (locks.Count > 0 && bullets.Count == 0)
            {
                PrintOutFail(locks);
            }
        }
        static Stack<int> WeaponFill()
        {
            Stack<int> bullets = new Stack<int>();
            int[] bull = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            foreach (int b in bull)
                bullets.Push(b);
            return bullets;
        }
        static Queue<int> LockFill()
        {
            var locks = new Queue<int>();
            int[] lockArr = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            foreach (int l in lockArr)
                locks.Enqueue(l);
            return locks;
        }
        static void PrintOutSucces(Stack<int> bullets, int bulletCount, int bulletPrice, int intelPrice)
        {
            int bulletsUsed = bulletCount - bullets.Count;
            int expenses = bulletsUsed * bulletPrice;
            Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelPrice - expenses}");
        }
        static void PrintOutFail(Queue<int> locks)
        {
            Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
        }
    }
}
