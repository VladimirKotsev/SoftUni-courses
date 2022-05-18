using System;
using System.Linq;

namespace _10._LadyBugs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //first section for input
            int length = int.Parse(Console.ReadLine());
            int[] field = new int[length];
            int[] littleGuys = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int i = 0; i < littleGuys.Length; i++)
            {
                if (littleGuys[i] >= 0 && littleGuys[i] <= length - 1)
                {
                    field[littleGuys[i]] = 1;
                }
            }
            //second section for looping
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] cmd = input.Split(' ').ToArray();
                int position = int.Parse(cmd[0]);
                string direction = cmd[1];
                int land = int.Parse(cmd[2]);
                if (position >= 0 && position <= length - 1)
                {
                    switch (direction)
                    {
                        case "left":
                            if (land > 0)
                            {
                                if (position != length - 1)
                                {
                                    field = MoveLittleGuyToLeft(field, position, land);
                                }
                                else
                                {
                                    field[position] = 0;
                                }
                            }
                            else if (land < 0)
                            {
                                if (position != length - 1)
                                {
                                    land = -land;
                                    field = MoveLittleGuyToRight(field, position, land);
                                }
                                else
                                {
                                    field[position] = 0;
                                }
                            }
                            break;

                        case "right":
                            if (land > 0)
                            {
                                if (position != length - 1)
                                {
                                    field = MoveLittleGuyToRight(field, position, land);
                                }
                                else
                                {
                                    field[position] = 0;
                                }
                            }
                            else if (land < 0)
                            {
                                if (position != length - 1)
                                {
                                    land = -land;
                                    field = MoveLittleGuyToLeft(field, position, land);
                                }
                                else
                                {
                                    field[position] = 0;
                                }
                            }
                            break;
                    }
                }

                input = Console.ReadLine();
            }
            //third section for output
            Console.WriteLine(String.Join(' ', field));
        }
        static int[] MoveLittleGuyToLeft(int[] field, int position, int tiles)
        {

            field[position] = 0;
            if (position - tiles >= 0)
            {
                if (field[position - tiles] == 0)
                {
                    field[position - tiles] = 1;
                }
                else if (field[position - tiles] == 1)
                {
                    while (field[position - tiles] == 1)
                    {
                        tiles++;
                        if (position - tiles < 0)
                        {
                            return field;
                        }
                    }
                    field[position - tiles] = 1;
                }
            }
            return field;
        }
        static int[] MoveLittleGuyToRight(int[] field, int position, int tiles)
        {
            field[position] = 0;
            if (position + tiles <= field.Length - 1)
            {
                if (field[position + tiles] == 0)
                {
                    field[position + tiles] = 1;
                }
                else if (field[position + tiles] == 1)
                {
                    while (field[position + tiles] == 1)
                    {
                        tiles++;
                        if (position + tiles > field.Length - 1)
                        {
                            return field;
                        }
                    }
                    field[position + tiles] = 1;
                }
            }

            return field;
        }
    }
}
