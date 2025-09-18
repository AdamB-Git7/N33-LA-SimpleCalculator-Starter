using System;
using System.Text;
using CalculatorLibrary;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Class to perform actual calculations
                CalculatorEngine calculatorEngine = new CalculatorEngine();

                // Get first number with validation
                double firstNumber;
                while (true)
                {
                    Console.Write("Enter the first number: ");
                    string input1 = Console.ReadLine();
                    if (double.TryParse(input1, out firstNumber))
                    {
                        break; // Valid input, exit loop
                    }
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }

                // Get second number with validation
                double secondNumber;
                while (true)
                {
                    Console.Write("Enter the second number: ");
                    string input2 = Console.ReadLine();
                    if (double.TryParse(input2, out secondNumber))
                    {
                        break; // Valid input, exit loop
                    }
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }

                // Get operation with validation and help text
                string operation;
                while (true)
                {
                    Console.Write("Enter the operation (+, -, *, /): ");
                    string input = Console.ReadLine();

                    // Check for valid symbols
                    if (input == "+" || input == "-" || input == "*" || input == "/")
                    {
                        operation = input;
                        break;
                    }

                    // Check for valid words and convert them
                    if (input?.ToLower() == "plus" || input?.ToLower() == "add")
                    {
                        operation = "+";
                        break;
                    }
                    else if (input?.ToLower() == "minus" || input?.ToLower() == "subtract")
                    {
                        operation = "-";
                        break;
                    }
                    else if (input?.ToLower() == "multiply" || input?.ToLower() == "times")
                    {
                        operation = "*";
                        break;
                    }
                    else if (input?.ToLower() == "divide" || input?.ToLower() == "divided")
                    {
                        operation = "/";
                        break;
                    }

                    // Show helpful error message (moved inside the loop)
                    Console.WriteLine("Invalid operation entered.");
                    Console.WriteLine("Valid operations are:");
                    Console.WriteLine("  + or 'plus' or 'add' for addition");
                    Console.WriteLine("  - or 'minus' or 'subtract' for subtraction");
                    Console.WriteLine("  * or 'multiply' or 'times' for multiplication");
                    Console.WriteLine("  / or 'divide' or 'divided' for division");
                    Console.WriteLine("Please try again.");
                    Console.WriteLine();
                }

                // Calculate and display result
                double result = calculatorEngine.Calculate(operation, firstNumber, secondNumber);

                // Create formatted output
                StringBuilder output = new StringBuilder();
                output.AppendFormat("The value {0:F2} {1} the value {2:F2} is equal to {3:F2}. ", firstNumber, operation, secondNumber, result);

                Console.WriteLine(output.ToString());
                Console.WriteLine($"Result: {result}");

            }
            catch (Exception ex)
            {
                // Normally, we'd log this error to a file.
                Console.WriteLine(ex.Message);
            }
        }
    }
}