using ExpressionEvaluator.Evaluate;
using Xunit;

namespace ExpressionEvaluator.Test
{
    public class EvaluaterUnitTest
    {
        private Evaluation evaluation;
        public EvaluaterUnitTest()
        {
            this.evaluation = new Evaluation();
        }

        [Fact]
        public void Addition_Substration_Test()
        {
            //arrange
            var expression = "10+2-6";

            //act 
            var result = evaluation.EvalExpression(expression);

            //assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void Addition_Substration_Multiply_Test()
        {
            //arrange
            var expression = "10+2-6*2";

            //act 
            var result = evaluation.EvalExpression(expression);

            //assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void With_Space_Addition_Substration_Multiply_Test()
        {
            //arrange
            var expression = " 10+2- 8*2";

            //act 
            var result = evaluation.EvalExpression(expression);

            //assert
            Assert.Equal(-4, result);
        }

        [Fact]
        public void With_Space_Addition_Substration_Multiply_Negative_Test()
        {
            //arrange
            var expression = " 10+2- 8*2";

            //act 
            var result = evaluation.EvalExpression(expression);

            //assert
            Assert.Equal(10, result);
        }

        [Fact]
        public void With_EmptyExpression_Test()
        {
            //arrange
            var expression = "";

            //act 
            var result = evaluation.EvalExpression(expression);

            //assert
            Assert.Equal(0, result);
        }
    }
}
