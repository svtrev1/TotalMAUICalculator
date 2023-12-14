
using FluentAssertions;
using System.Data;
using Parser;
namespace UnitTestProject
{
    public class CalculatorTests
    {

        Calculator _calculator = new Calculator();
     
        [Fact]
        public void Add_double_and_double()
        {
            _calculator.s = "1,1+2,2\0";
            _calculator.i = 0;
            double result = _calculator.Cal();
            Assert.Equal(3.3, result);
        }
        [Fact]
        public void Add_and_multiplication()
        {
            _calculator.s = "2+2*2\0";
            _calculator.i = 0;
            double result = _calculator.Cal();
            Assert.Equal(6, result);
        }
        [Fact]
        public void Multiplication_and_division()
        {
            _calculator.s = "5*7/2\0"; _calculator.i = 0;
            double result = _calculator.Cal();
            Assert.Equal(17.5, result);
        }
        [Fact]
        public void Division_null_and_number()
        {
            _calculator.s = "0/2\0";
            _calculator.i = 0;
            double result = _calculator.Cal();
            Assert.Equal(0, result);
        }
        [Fact]
        public void Error_unequal_number_of_parentheses()
        {
            _calculator.s = "(3+4)*(4+8\0";
            _calculator.i = 0;
            _calculator.Cal();
            _calculator.c.Should().Be(true);
        }
        [Fact]
        public void Error_incorrect_order_of_parentheses()
        {
            _calculator.s = ")3+4(\0";
            _calculator.i = 0;
            _calculator.Cal();
            _calculator.c.Should().Be(true);
        }
        [Fact]
        public void Error_unequal_of_identical_parentheses()
        {
            _calculator.s = ")3+4(\0";
            _calculator.i = 0;
            _calculator.Cal();
            _calculator.c.Should().Be(true);
        }
    }
}