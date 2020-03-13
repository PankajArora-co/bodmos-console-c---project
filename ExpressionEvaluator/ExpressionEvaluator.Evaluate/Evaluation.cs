using System;
using System.Text;

namespace ExpressionEvaluator.Evaluate
{
    public class Evaluation
    {
        public double EvalExpression(string expr)
        {
            if (string.IsNullOrEmpty(expr))
                return 0;

            char[] expression = RemoveWhiteSpace(expr.ToCharArray());

            return ParseExpression(expression, 0);
        }

        private char[] RemoveWhiteSpace(char[] expr)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < expr.Length; i++)
            {
                if (!Char.IsWhiteSpace(expr[i]) && (int)expr[i] != 34)
                {
                    stringBuilder.Append(expr[i]);
                }
            }
            return stringBuilder.ToString().ToCharArray();
        }

        private double ParseExpression(char[] expr, int index)
        {
            double x = ParseFactors(expr, ref index);
            while (true)
            {
                char op = expr[index];
                if (op != '+' && op != '-')
                    return x;
                index++;

                double y = ParseFactors(expr, ref index);
                if (op == '+')
                    x += y;
                else
                    x -= y;
            }
        }

        private double ParseFactors(char[] expr, ref int index)
        {
            double x = GetDouble(expr, ref index);
            while (true)
            {
                char op = expr[index];
                if (op != '*')
                    return x;
                index++;
                double y = GetDouble(expr, ref index);
                if (op == '*')
                    x *= y;
            }
        }

        private double GetDouble(char[] expr, ref int index)
        {
            string dbl = string.Empty; ;
            while (((int)expr[index] >= 48 && (int)expr[index] <= 57) || expr[index] == 46)
            {
                dbl = dbl + expr[index].ToString();
                index++;
                if (index == expr.Length)
                {
                    index--;
                    break;
                }
            }
            return double.Parse(dbl);
        }
    }
}
