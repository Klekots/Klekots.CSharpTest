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
            List<uint> IndividualSpeed = new List<uint>();

            Console.WriteLine("Enter Images Count");
            uint PictureCount = Conv();

            Console.WriteLine("Enter People Count");
            uint PeopleCount = Conv();

            for(var i = 0; i < PeopleCount; i++)
            {
                Console.WriteLine($"Enter people {i+1} speed");
                IndividualSpeed.Add(Conv());
            }

            float FirstStep(uint peopleCount,List<uint> individualSpeed)
            {
                float allPeopleWork = 0;
                for(var i = 0; i < peopleCount; i++)
                {
                    allPeopleWork += ((float)1 / individualSpeed[i]);
                }

                return allPeopleWork;
            }

            uint time = (uint)(PictureCount / FirstStep(PeopleCount, IndividualSpeed));

            uint SecondStep(uint peopleCount, List<uint> individualSpeed)
            {
                float sum = 0;

                for (var i = 0; i < peopleCount; i++)
                {
                    sum += (time / individualSpeed[i]);
                }
                return (uint)sum;
            }

            while (SecondStep(PeopleCount, IndividualSpeed) < PictureCount)
            {
                time++;
            }

            Console.WriteLine(time);
            Console.ReadLine();
        }
    }
}
