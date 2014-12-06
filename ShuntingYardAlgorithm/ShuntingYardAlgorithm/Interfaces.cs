using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuntingYardAlgorithm
{
    interface MathToken
    {
    }

    interface Operator : MathToken
    {
        char Symbol { get; }

        bool LeftAssociative { get; }
        int Precedence { get; }

        double Operate(params double[] values);
    }

    
}
