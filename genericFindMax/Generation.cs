using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genericFindMax
{
    class Generation
    {
        public int X0 { get; set; }
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int X3 { get; set; }
       

        private Random random = new Random();

        public Generation(int start, int end)
        {
            createFirstGeneration(start, end);
        }
        public Generation(int X0, int X1, int X2, int X3)
        {
            this.X0 = X0;
            this.X1 = X1;
            this.X2 = X2;
            this.X3 = X3;
        }
        private void createFirstGeneration(int start, int end)
        {
            int interval = (end - start)/4;
            X0 = random.Next(start, end/4+ start);
            X1 = X0 + interval;
            X2 = X1 + interval;
            X3 = X2 + interval;
        }
        
        

    }
}
