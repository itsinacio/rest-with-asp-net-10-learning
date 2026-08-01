namespace RestWithASPNET.Services;
using System;

public class MathService
{
    public decimal Sum(decimal firstNumber, decimal secondNumber) => firstNumber + secondNumber;
    public decimal Subtration(decimal firstNumber, decimal secondNumber) => firstNumber - secondNumber;
    public decimal Multiplication(decimal firstNumber, decimal secondNumber) => firstNumber * secondNumber;
    public decimal Division(decimal firstNumber, decimal secondNumber)
    {
        if (secondNumber == 0) throw new DivideByZeroException("Division by zero is not allowed");
        return firstNumber / secondNumber;
    }
    public decimal Average(decimal firstNumber, decimal secondNumber) => (firstNumber + secondNumber) / 2;
    public double SquareRoot(decimal number)
    {
        if (number < 0) throw new ArgumentOutOfRangeException("Cannot calculate the squarre root of a negativa number");
        return Math.Sqrt((double)number);
    }
}
