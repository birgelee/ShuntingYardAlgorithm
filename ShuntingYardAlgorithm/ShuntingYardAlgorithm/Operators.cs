using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuntingYardAlgorithm
{
    class Plus : Operator
    {
        public char Symbol { get { return '+'; } }

        public bool LeftAssociative { get { return true; } }

        public int Precedence { get { return 4; } }


        public double Operate(params double[] values)
        {
            return values[0] + values[1];
        }

    }

    class Minus : Operator
    {

        public char Symbol { get { return '-'; } }
        public bool LeftAssociative { get { return true; } }

        public int Precedence { get { return 4; } }

        public double Operate(params double[] values)
        {
            return values[0] - values[1];
        }

    }

    class Multiplication : Operator
    {
        public char Symbol { get { return '*'; } }
        public bool LeftAssociative { get { return true; } }

        public int Precedence { get { return 5; } }


        public double Operate(params double[] values)
        {
            return values[0] * values[1];
        }

    }
    class Divide : Operator
    {
        public char Symbol { get { return '/'; } }
        public bool LeftAssociative { get { return true; } }

        public int Precedence { get { return 5; } }


        public double Operate(params double[] values)
        {
            return values[0] / values[1];
        }

    }

    class Mod : Operator
    {
        public char Symbol { get { return '%'; } }
        public bool LeftAssociative { get { return true; } }

        public int Precedence { get { return 5; } }


        public double Operate(params double[] values)
        {
            return values[0] % values[1];
        }

    }

    class Power : Operator
    {
        public char Symbol { get { return '^'; } }
        public bool LeftAssociative { get { return true; } }

        public int Precedence { get { return 6; } }


        public double Operate(params double[] values)
        {
            return values[0] % values[1];
        }

    }
    
}
