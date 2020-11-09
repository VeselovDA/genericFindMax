using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace genericFindMax
{
    class Crossing
    {
        double[] Fx = new double[4];// массив фитнесс-функций
        int[] X = new int[4];// массив поколения
        double a;
        double b;
        double c;
        double d;
        Random random = new Random();//создание рандома


        public Crossing(Generation generation)
        {
            
            X[0] = generation.X0;
            X[1] = generation.X1;
            X[2] = generation.X2;
            X[3] = generation.X3;
           
        }
        void getFitnessFunc()
        {
            double correctionValue = 0;// корректировочное значение для предствления фитнессфункции >0
            for (int i = 0; i < 4; i++)
            {

                Fx[i] = FitnessFunction.getFitnessFunction(X[i]);
                if (i == 0)
                     correctionValue = Fx[i];
                else if(Fx[i]< correctionValue)
                    correctionValue = Fx[i];
            }
            if(correctionValue<0)
            for (int i = 0; i < 4; i++)
                Fx[i] -= correctionValue;

            double summ = Fx[0] + Fx[1] + Fx[2] + Fx[3];
            a = 360 * Fx[0] / summ;
            b = 360 * Fx[1] / summ + a;
            c = 360 * Fx[2] / summ + b;
            d = 360 * Fx[3] / summ + c;
        }
        private int startRoulette()
        {
           
            int value = 0;
            int rand = random.Next(0, 360);
            if (rand <= a) value = X[0];
            if (rand <= b && rand > a) value = X[1];
            if (rand <= c && rand > b) value = X[2];
            if (rand <= d && rand > c) value = X[3];
            return value;
        }
        private void Selection()
        {
            int first;
            int second;
            uint First;
            uint Second;
            for (int i = 0; i < 4; i++)
            {
                first = startRoulette();
                second = startRoulette();
                First = (uint)first;
                Second = (uint)second;
                First = First >> 3 << 3;
                Second &= 7;
                X[i] = (int)(First | Second);
            }
           
        }
        public Generation startCrossing()
        {
            getFitnessFunc();
            Selection();
            return new Generation(X[0], X[1], X[2], X[3]);
        }

        
    }
}
