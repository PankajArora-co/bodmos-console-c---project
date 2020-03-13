using ExpressionEvaluator.Evaluate;
using System;

namespace ExpressionEvaluator
{
    public class Expressions
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter expression: ");
            string line = Console.ReadLine();

            Evaluation evaluation = new Evaluation();
            double value = evaluation.EvalExpression(line);

            Console.WriteLine("{0} = {1}", line, value);
            Console.ReadKey();
        }
    }
}
