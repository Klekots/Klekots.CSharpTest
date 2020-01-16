using System;

namespace Klekots.SecondApp
{
    class Worker
    {
        static uint WorkersCount { get; set; } = 1;
        public uint Speed { get; set; }
        public uint PhotoCheckedCount { get; set; }
        public uint WorkerID { get; }
        public Worker(uint speed, uint photoChecked)
        {
            Speed = speed;
            PhotoCheckedCount = photoChecked;
            WorkerID = WorkersCount;
            WorkersCount++;
        }
    }
}
