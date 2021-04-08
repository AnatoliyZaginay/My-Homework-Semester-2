using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Operand : ITreeElement
    {
        private double value;

        public Operand(double value)
        {
            this.value = value;
        }

        public double Calculate()
            => value;

        public string Print()
            => value.ToString();
    }
}
