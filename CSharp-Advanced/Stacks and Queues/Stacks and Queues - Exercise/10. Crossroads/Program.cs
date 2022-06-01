using System;
using System.Collections.Generic;
using System.Text;

namespace _10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<char> crossroad = new Queue<char>();
            int greenDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            int green = greenDuration;
            int yellow = freeWindowDuration;
            int carCounter = 0;
            bool alreadyEntered = false;
            StringBuilder currCar = new StringBuilder();
            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] cmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (command != "green")
                {
                    crossroad = QueueUp(crossroad, cmd[0]);
                    green = greenDuration;
                    yellow = freeWindowDuration;
                }
                else
                {
                    green = greenDuration;
                    int count = crossroad.Count;
                    for (int i = 0; i < count; i++)
                    {
                        if (crossroad.Peek() == ' ')
                        {
                            carCounter++;
                            crossroad.Dequeue();
                            currCar.Clear();
                            if (green == 0)
                            {
                                break;
                            }
                            continue;
                        }
                        if (green == 0)
                        {
                            if (yellow > 0 && alreadyEntered == true)
                            {
                                yellow--;
                                currCar.Append(crossroad.Dequeue().ToString().ToString());
                                continue;
                            }
                            else if (yellow > 0 && alreadyEntered == false)
                            {
                                Console.WriteLine("Everyone is safe.");
                                return;
                            }
                            else
                            {
                                int count1 = crossroad.Count;
                                char hitIndex = crossroad.Peek();
                                for (int j = 0; j < count1 - 1; j++)
                                    currCar.Append(crossroad.Dequeue().ToString());
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{currCar} was hit at {hitIndex}.");
                                return;
                            }
                        }
                        alreadyEntered = true;
                        green--;
                        currCar.Append(crossroad.Dequeue().ToString());
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carCounter} total cars passed the crossroads.");
        }
        static Queue<char> QueueUp(Queue<char> queue, string toQueueUp)
        {
            foreach (char c in toQueueUp)
            {
                queue.Enqueue(c);
            }
            queue.Enqueue(' ');
            return queue;
        }
    }
}
