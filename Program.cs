
/*******************************************************************
 * Name: Anthony Seldon
 * Date: November 8, 2026
 * Assignment: SDC220 Final Calculator Project
 *
 * Program class.
 * This is the main application for the calculator. It provides
 * a menu for mathematical operations and memory management.
 *******************************************************************/

using System;
using System.Collections.Generic;
using System.Globalization;

public class Program
{
    // Create calculator and memory objects
    static Calculator calculator = new Calculator();
    static MemoryManager memory = new MemoryManager();

    static void Main(string[] args)
    {
        DisplayHeader();

        bool running = true;

        // Keep displaying the menu until the user quits
        while (running)
        {
            DisplayMenu();

            Console.Write("Select an option: ");
            string choice = Console.ReadLine() ?? "";

            Console.WriteLine();

            switch (choice.Trim())
            {
                case "1":
                    PerformCalculation('+', "Addition");
                    break;

                case "2":
                    PerformCalculation('-', "Subtraction");
                    break;

                case "3":
                    PerformCalculation('*', "Multiplication");
                    break;

                case "4":
                    PerformCalculation('/', "Division");
                    break;

                case "5":
                    StoreMemoryValue();
                    break;

                case "6":
                    RecallMemoryValue();
                    break;

                case "7":
                    memory.DisplayMemory();
                    break;

                case "8":
                    memory.ClearMemory();
                    Console.WriteLine("Memory cleared.");
                    break;

                case "0":
                    running = false;
                    Console.WriteLine("Thank you for using the calculator!");
                    break;

                default:
                    Console.WriteLine(
                        "Invalid selection. Please choose a menu option.");
                    break;
            }

            Console.WriteLine();
        }
    }

    // Displays the program heading
    static void DisplayHeader()
    {
        Console.WriteLine("Anthony Seldon - Final Calculator Project");
        Console.WriteLine("Welcome to the calculator!");
        Console.WriteLine("Enter multiple numbers for each operation.");
        Console.WriteLine("You can also store and recall up to 10 memory values.");
        Console.WriteLine();
    }

    // Displays the main menu
    static void DisplayMenu()
    {
        Console.WriteLine("===== CALCULATOR MENU =====");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");
        Console.WriteLine("5. Store a value in memory");
        Console.WriteLine("6. Recall a memory value");
        Console.WriteLine("7. Display memory");
        Console.WriteLine("8. Clear memory");
        Console.WriteLine("0. Quit");
        Console.WriteLine();
    }

    // Gets numbers and performs the selected operation
    static void PerformCalculation(char operation, string operationName)
    {
        List<double> numbers = ReadNumbers();

        try
        {
            double result = calculator.Calculate(numbers, operation);

            Console.WriteLine(
                "{0} Result: {1:F2}", operationName, result);
        }
        catch (DivideByZeroException e)
        {
            Console.WriteLine("Calculation error: " + e.Message);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("Calculation error: " + e.Message);
        }
    }

    // Reads multiple numeric values from the user
    static List<double> ReadNumbers()
    {
        while (true)
        {
            Console.Write(
                "Enter at least two numbers separated by spaces: ");

            string input = Console.ReadLine() ?? "";

            string[] values = input.Split(
                new char[] { ' ', '\t', ',' },
                StringSplitOptions.RemoveEmptyEntries);

            if (values.Length < 2)
            {
                Console.WriteLine(
                    "Please enter at least two numbers.");
                continue;
            }

            List<double> numbers = new List<double>();
            bool validInput = true;

            foreach (string value in values)
            {
                if (double.TryParse(
                    value,
                    NumberStyles.Float | NumberStyles.AllowThousands,
                    CultureInfo.CurrentCulture,
                    out double number))
                {
                    numbers.Add(number);
                }
                else
                {
                    Console.WriteLine(
                        "Invalid input. Please enter numeric values.");
                    validInput = false;
                    break;
                }
            }

            if (validInput)
            {
                return numbers;
            }
        }
    }

    // Stores a numeric value in memory
    static void StoreMemoryValue()
    {
        Console.Write("Enter a value to store: ");
        string input = Console.ReadLine() ?? "";

        if (double.TryParse(input, out double value))
        {
            if (memory.StoreValue(value))
            {
                Console.WriteLine("Value stored successfully.");
            }
            else
            {
                Console.WriteLine(
                    "Memory is full. You can only store 10 values.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    // Retrieves a value from memory
    static void RecallMemoryValue()
    {
        if (memory.Count == 0)
        {
            Console.WriteLine("Memory is empty.");
            return;
        }

        memory.DisplayMemory();

        Console.Write("Enter the memory position to recall: ");
        string input = Console.ReadLine() ?? "";

        if (int.TryParse(input, out int position))
        {
            try
            {
                double value = memory.RecallValue(position);

                Console.WriteLine(
                    "Recalled value: {0:F2}", value);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Memory error: " + e.Message);
            }
        }
        else
        {
            Console.WriteLine("Invalid memory position.");
        }
    }
}
