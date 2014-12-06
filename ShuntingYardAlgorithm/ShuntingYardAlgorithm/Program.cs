using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuntingYardAlgorithm
{
    class Program
    {
        public static IEnumerable<System.Type> operators;
        static void Main(string[] args)
        {
            var oType = typeof(Operator);
            operators = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => oType.IsAssignableFrom(p) && p != oType);



            string usrIn = Console.ReadLine();
            Console.WriteLine(Evaluate(usrIn));
            Console.ReadLine();
            
        }


        static double Evaluate(string expr)
        {
            return new ShuntingYard(expr).Eval();
        }
    }
}
