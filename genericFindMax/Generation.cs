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

        public bool Mutation { get; set; }


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
        public Generation(int X0, int X1, int X2, int X3,bool checkMutation)
        {
            this.X0 = X0;
            this.X1 = X1;
            this.X2 = X2;
            this.X3 = X3;
            Mutation = checkMutation;
        }
        private void createFirstGeneration(int start, int end)
        {
            int interval = (end - start)/4;
            X0 = random.Next(start, end/4+ start);
            X1 = X0 + interval;
            X2 = X1 + interval;
            X3 = X2 + interval;
        }

        public Generation mutation()
        {
            int[] X = new int[4] { X0, X1, X2, X3 };

            int randX = random.Next(0, 4);
            int randBit = random.Next(1, 5);
            uint help = (uint)X[randX];
            help = (uint)(help ^ (1 << (randBit - 1)));
            X[randX] = Convert.ToInt32(help);

            return new Generation(X[0],X[1], X[2], X[3],true);
           
        }
        
        

    }
}
