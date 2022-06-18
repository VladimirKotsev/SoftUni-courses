using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._The_Fight_for_Gondor
{
    public class Program
    {
        static void Main(string[] args)
        {
            //input
            Queue<int> defence = new Queue<int>();
            Stack<int> wave = new Stack<int>();
            int nWaves = int.Parse(Console.ReadLine());
            defence = EnqueueMethod();

            for (int i = 1; i <= nWaves; i++)
            {
                wave = WaveMethod();
                if (i % 3 == 0)
                    defence.Enqueue(int.Parse(Console.ReadLine()));
                (defence, wave) = AttackSimulation(defence, wave);
                if (defence.Count == 0)
                {
                    break;
                }
            }
            if (defence.Count == 0 && wave.Count > 0)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {String.Join(", ", wave)}");
            }
            else if (defence.Count > 0 && wave.Count == 0)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {String.Join(", ", defence)}");
            }
        }
        static Queue<int> EnqueueMethod()
        {
            var queue = new Queue<int>();
            int[] plates = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            foreach (var plate in plates)
            {
                queue.Enqueue(plate);
            }
            return queue;
        }
        static Stack<int> WaveMethod()
        {
            var stack = new Stack<int>();
            int[] wave = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            foreach (var orc in wave)
            {
                stack.Push(orc);
            }
            return stack;
        }
        static (Queue<int>, Stack<int>) AttackSimulation(Queue<int> defence, Stack<int> wave)
        {
            int count = wave.Count();
            while (true)
            {
                if (defence.Count > 0 && wave.Count > 0)
                {
                    int currentOrc = wave.Pop();
                    int hitPointsDefence = defence.Peek();
                    hitPointsDefence -= currentOrc;
                    if (hitPointsDefence == 0) // defence == orc
                        defence.Dequeue();
                    else if (hitPointsDefence < 0) //defence < orc
                    {
                        wave.Push(-hitPointsDefence);
                        defence.Dequeue();
                    }
                    else if (hitPointsDefence > 0)
                        defence = ResetQueue(defence, hitPointsDefence);
                }
                else break;
            }
            return (defence, wave);
        }
        static Queue<int> ResetQueue(Queue<int> defence, int hitPoints)
        {
            int pointToEnqueue = hitPoints;
            int count = defence.Count;
            defence.Enqueue(pointToEnqueue);
            defence.Dequeue();
            for (int i = 0; i < count - 1; i++)
            {
                defence.Enqueue(defence.Dequeue());
            }
            return defence;
        }
    }
}
