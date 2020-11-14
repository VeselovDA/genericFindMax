using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genericFindMax
{
     static class FitnessFunction
    {
        public static double getFitnessFunction(int value) => -((value - 16) * (value - 16))+30;
        //public static double getFitnessFunction(int value) => value;
    }
}
