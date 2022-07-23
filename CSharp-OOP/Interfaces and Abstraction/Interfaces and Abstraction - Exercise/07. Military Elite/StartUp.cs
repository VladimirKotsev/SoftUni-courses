namespace _07._Military_Elite
{
    using System;
    using System.Collections.Generic;
    using Models;
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Private> privates = new List<Private>();

            string[] sArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (sArgs[0] != "End")
            {
                int id = int.Parse(sArgs[1]);
                string firstName = sArgs[2];
                string lastName = sArgs[3];

                if (sArgs[0] == "Private")
                {
                    Private newPrivate = new Private
                        (id, firstName, lastName, decimal.Parse(sArgs[4]));
                    privates.Add(newPrivate);
                    Console.WriteLine(newPrivate);
                }
                else if (sArgs[0] == "LieutenantGeneral")
                {
                    LieutenantGeneral newLieutenant = new LieutenantGeneral
                        (id, firstName, lastName, decimal.Parse(sArgs[4]));
                    for (int i = 5; i < sArgs.Length; i++)
                    {
                        newLieutenant.AddPrivate(privates.Find
                            (x => x.Id == int.Parse(sArgs[i])));
                    }
                    Console.WriteLine(newLieutenant);
                }
                else if (sArgs[0] == "Engineer")
                {
                    try
                    {
                        Engineer newEngineer = new Engineer
                           (id, firstName, lastName, decimal.Parse(sArgs[4]), sArgs[5]);
                        for (int i = 6; i < sArgs.Length; i += 2)
                        {
                            Repair newRepair = new Repair
                                (sArgs[i], int.Parse(sArgs[i + 1]));
                            newEngineer.AddRepair(newRepair);
                        }
                        Console.WriteLine(newEngineer);
                    }
                    catch (ArgumentException)
                    {

                    }
                }
                else if (sArgs[0] == "Commando")
                {
                    try
                    {
                        Commando newCommando = new Commando
                            (id, firstName, lastName, decimal.Parse(sArgs[4]), sArgs[5]);
                        for (int i = 6; i < sArgs.Length; i += 2)
                        {
                            try
                            {
                                Mission newMission = new Mission(sArgs[i], sArgs[i + 1]);
                                newCommando.AddMission(newMission);
                            }
                            catch (ArgumentException)
                            {

                            }
                        }
                        Console.WriteLine(newCommando);
                    }
                    catch (ArgumentException)
                    {

                    }
                }
                else if (sArgs[0] == "Spy")
                {
                    Spy newSpy = new Spy(id, firstName, lastName, int.Parse(sArgs[4]));
                    Console.WriteLine(newSpy);
                }

                sArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

        }
    }
}
