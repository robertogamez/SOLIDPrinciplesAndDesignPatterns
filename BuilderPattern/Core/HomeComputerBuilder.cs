using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuilderPattern.Core
{
    public class HomeComputerBuilder : IComputerBuilder
    {
        public AppDbContext AppDbContext { get; }

        private Computer computer;

        public HomeComputerBuilder(AppDbContext appDbContext)
        {
            this.AppDbContext = appDbContext;
            computer = new Computer();
            computer.Parts = new List<ComputePart>();
        }

        public void AddCabinet()
        {
            var query = from p in AppDbContext.ComputerParts
                        where p.UseType == "HOME" && p.Part == "CABINET"
                        select p;
            computer.Parts.Add(query.SingleOrDefault());
        }

        public void AddCPU()
        {
            var query = from p in AppDbContext.ComputerParts
                        where p.UseType == "HOME" && p.Part == "CPU"
                        select p;

            computer.Parts.Add(query.SingleOrDefault());
        }

        public void AddMouse()
        {
            var query = from p in AppDbContext.ComputerParts
                        where p.UseType == "HOME" && p.Part == "MOUSE"
                        select p;
            computer.Parts.Add(query.SingleOrDefault());
        }
        public void AddKeyboard()
        {
            var query = from p in AppDbContext.ComputerParts
                        where p.UseType == "HOME" && p.Part == "KEYBOARD"
                        select p;
            computer.Parts.Add(query.SingleOrDefault());
        }
        public void AddMonitor()
        {
            var query = from p in AppDbContext.ComputerParts
                        where p.UseType == "HOME" && p.Part == "MONITOR"
                        select p;
            computer.Parts.Add(query.SingleOrDefault());
        }

        public Computer GetComputer()
        {
            return computer;
        }
    }
}
