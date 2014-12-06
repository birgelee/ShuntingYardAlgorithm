using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuntingYardAlgorithm
{
    class ShuntingYard
    {
        string expr;
        int index = 0;

        List<MathToken> output = new List<MathToken>(), operatorStack = new List<MathToken>();

        public ShuntingYard(string ex)
        {
            expr = ex;
        }

        public double Eval()
        {
            while (true)
            {
                if (index >= expr.Count())
                {
                    while (operatorStack.Count > 0)
                    {
                        output.Add(operatorStack[operatorStack.Count - 1]);
                        operatorStack.RemoveAt(operatorStack.Count - 1);
                    }
                    break;
                }
                char ch = expr[index];

                if (Char.IsDigit(ch) || ch == '.')
                {
                    var nt = new NumberToken();
                    int endIndex = index;
                    while (++endIndex < expr.Count() && (Char.IsDigit(expr[endIndex]) || expr[endIndex] == '.')) { }
                    nt.Value = Double.Parse(expr.Substring(index, endIndex - index));
                    output.Add(nt);
                    index = endIndex;
                }
                else
                {
                    System.Type op;
                    try
                    {
                        op = Program.operators.First(o => ((Operator)(o.GetConstructor(System.Type.EmptyTypes).Invoke(null))).Symbol == ch);
                    }
                    catch (InvalidOperationException ex) { op = null; }
                    
                    if (op != null)
                    {
                        Operator o1 = ((Operator)(op.GetConstructor(System.Type.EmptyTypes).Invoke(null)));
                        while (operatorStack.Count != 0 && typeof(Operator).IsAssignableFrom(operatorStack[operatorStack.Count - 1].GetType()))
                        {
                            Operator o2 = (Operator)operatorStack[operatorStack.Count - 1];//Will break with (
                            if ((o1.LeftAssociative && o1.Precedence <= o2.Precedence) || o1.Precedence < o2.Precedence)
                            {
                                operatorStack.RemoveAt(operatorStack.Count - 1);
                                output.Add(o2);
                            }
                            else
                            {
                                break;
                            }
                        }
                        operatorStack.Add(o1);
                        index++;
                    }
                    else if (ch == '(')
                    {
                        operatorStack.Add(new LeftParens());
                        index++;
                    }
                    else if (ch == ')')
                    {

                        MathToken stackPop;
                        index++;
                        try
                        {
                            while ((stackPop = operatorStack[operatorStack.Count - 1]) != null)
                            {
                                operatorStack.RemoveAt(operatorStack.Count - 1);
                                if (stackPop.GetType() != typeof(LeftParens))
                                {
                                    output.Add(stackPop);
                                }
                                else
                                {
                                    break;//Here is where I would handle function calls.
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("There was no opening parens.");
                        }
                    }
                }

            }
            return EvalOutputStack();
        }

        private double EvalOutputStack()
        {
            int index = 0;
            while (index < output.Count) {
                if (typeof(Operator).IsAssignableFrom(output[index].GetType()))
                {
                    var val = ((Operator)output[index]).Operate(((NumberToken)output[index - 2]).Value, ((NumberToken)output[index - 1]).Value);
                    NumberToken nt = new NumberToken();
                    nt.Value = val;
                    output[index] = nt;
                    output.RemoveAt(index - 1);
                    output.RemoveAt(index - 2);
                    index = 0;
                }
                else
                {
                    index++;
                }
            }
            return ((NumberToken)output[0]).Value;
        }
    }
}
