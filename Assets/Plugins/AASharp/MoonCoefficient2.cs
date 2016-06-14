using System;
using System.Collections.Generic;
using System.Linq;

namespace AASharp
{
    internal struct MoonCoefficient2
    {
        internal MoonCoefficient2(double a, double b)
        {
            _A = a;
            _B = b;
        }

        private readonly double _A;
        public double A
        {
            get
            {
                return _A;
            }
        }
        private readonly double _B;
        public double B
        {
            get
            {
                return _B;
            }
        }
    }
}
