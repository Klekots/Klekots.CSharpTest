using System;
using System.Collections.Generic;

namespace Klekots.SecondApp
{
    class Program
    {
        static uint Conv()
        {
            return Convert.ToUInt32(Console.ReadLine());
        }
        static void Main(string[] args)
        {
            List<Worker> Workers = new List<Worker>();

            Console.WriteLine("Enter Images Count");
            uint PictureCount = Conv();

            Console.WriteLine("Enter People Count");
            uint PeopleCount = Conv();

            for (var i = 0; i < PeopleCount; i++)
            {
                Console.WriteLine($"Enter people {i + 1} speed");
                Workers.Add(new Worker(Conv(), 0));
            }

            float FirstStep(uint peopleCount, List<Worker> workers)
            {
                float allPeopleWork = 0;
                for (var i = 0; i < peopleCount; i++)
                {
                    allPeopleWork += ((float)1 / workers[i].Speed);
                }

                return allPeopleWork;
            }

            uint time = (uint)(PictureCount / FirstStep(PeopleCount, Workers));

            uint SecondStep(uint peopleCount, List<Worker> workers)
            {
                float sum = 0;

                for (var i = 0; i < peopleCount; i++)
                {
                    sum += (time / workers[i].Speed);
                }
                return (uint)sum;
            }

            while (SecondStep(PeopleCount, Workers) < PictureCount)
            {
                time++;
            }

            for (var i = 0; i < PeopleCount; i++)
            {
                Workers[i].PhotoCheckedCount = time / Workers[i].Speed;
            }

            Workers.Sort((Worker first, Worker second) =>
            {
                if (first.PhotoCheckedCount > second.PhotoCheckedCount)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            });

            uint CheckedSum(uint peopleCount, List<Worker> workers)
            {
                uint sum = 0;
                for (var i = 0; i < peopleCount; i++)
                {
                    sum += workers[i].PhotoCheckedCount;
                }
                return sum;
            }

            for(var i = (int)PeopleCount-1; CheckedSum(PeopleCount, Workers) > PictureCount; i--)
            {
                Workers[i].PhotoCheckedCount--;
            }

            foreach (Worker people in Workers)
            {
                Console.WriteLine($"Worker id: {people.WorkerID} checked {people.PhotoCheckedCount} photos");
            }

            Console.WriteLine($"Time needed to complete task :  {time}");
            Console.ReadLine();
        }
    }
}