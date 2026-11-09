/*******************************************************************
 * Name: Anthony Seldon
 * Date: November 8, 2026
 * Assignment: SDC220 Final Calculator Project
 *
 * Calculator class.
 * This class performs addition, subtraction, multiplication,
 * and division on multiple numeric values.
 *******************************************************************/

using System;
using System.Collections.Generic;

public class Calculator
{
    // Performs a mathematical operation on multiple numbers
    public double Calculate(List<double> numbers, char operation)
    {
        if (numbers == null || numbers.Count < 2)
        {
            throw new ArgumentException(
                "At least two numbers are required.");
        }

        double result = numbers[0];

        // Process each number using the selected operation
        for (int i = 1; i < numbers.Count; i++)
        {
            switch (operation)
            {
                case '+':
                    result += numbers[i];
                    break;

                case '-':
                    result -= numbers[i];
                    break;

                case '*':
                    result *= numbers[i];
                    break;

                case '/':
                    if (numbers[i] == 0)
                    {
                        throw new DivideByZeroException(
                            "Cannot divide by zero.");
                    }

                    result /= numbers[i];
                    break;

                default:
                    throw new ArgumentException(
                        "Invalid mathematical operation.");
            }
        }

        return result;
    }
}