using Common;
using System;

namespace Infrastructure
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;
        public DateTime UtcNow => DateTime.UtcNow;

        public int CurrentYear => DateTime.Now.Year;
    }
}
