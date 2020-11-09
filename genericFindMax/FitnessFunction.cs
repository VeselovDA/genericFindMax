using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genericFindMax
{
     static class FitnessFunction
    {
        //public static double getFitnessFunction(int value) => -((value - 3) * (value - 3));
        public static double getFitnessFunction(int value) => value;
    }
}
