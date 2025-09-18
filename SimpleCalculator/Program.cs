using System;
using System.Globalization;
using System.Text;
using System.Threading;
using SimpleCalculator.Ressources;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Language selection
                Console.Write(Strings.SelectLanguage);
                string langChoice = Console.ReadLine();

                if (langChoice == "2")
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
                }
                else
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                }

                // Class to perform actual calculations
                CalculatorEngine calculatorEngine = new CalculatorEngine();

                // Get first number with validation
                double firstNumber;
                while (true)
                {
                    Console.Write(Strings.EnterFirstNumber);
                    string input1 = Console.ReadLine();
                    if (double.TryParse(input1, out firstNumber))
                    {
                        break; // Valid input, exit loop
                    }
                    Console.WriteLine(Strings.InvalidInput);
                }

                // Get second number with validation
                double secondNumber;
                while (true)
                {
                    Console.Write(Strings.EnterSecondNumber);
                    string input2 = Console.ReadLine();
                    if (double.TryParse(input2, out secondNumber))
                    {
                        break; // Valid input, exit loop
                    }
                    Console.WriteLine(Strings.InvalidInput);
                }

                // Get operation with validation and help text
                string operation;
                while (true)
                {
                    Console.Write(Strings.EnterOperation);
                    string input = Console.ReadLine();

                    // Check for valid symbols
                    if (input == "+" || input == "-" || input == "*" || input == "/")
                    {
                        operation = input;
                        break;
                    }

                    // Check for valid words and convert them (using localized strings)
                    if (input?.ToLower() == Strings.Plus || input?.ToLower() == Strings.Add)
                    {
                        operation = "+";
                        break;
                    }
                    else if (input?.ToLower() == Strings.Minus || input?.ToLower() == Strings.Subtract)
                    {
                        operation = "-";
                        break;
                    }
                    else if (input?.ToLower() == Strings.Multiply || input?.ToLower() == Strings.Times)
                    {
                        operation = "*";
                        break;
                    }
                    else if (input?.ToLower() == Strings.Divide || input?.ToLower() == Strings.Divided)
                    {
                        operation = "/";
                        break;
                    }

                    // Show helpful error message (moved inside the loop)
                    Console.WriteLine(Strings.InvalidOperation);
                    Console.WriteLine(Strings.ValidOperations);
                    Console.WriteLine(Strings.AdditionHelp);
                    Console.WriteLine(Strings.SubtractionHelp);
                    Console.WriteLine(Strings.MultiplicationHelp);
                    Console.WriteLine(Strings.DivisionHelp);
                    Console.WriteLine(Strings.TryAgain);
                    Console.WriteLine();
                }

                // Calculate and display result
                double result = calculatorEngine.Calculate(operation, firstNumber, secondNumber);

                // Create formatted output using localized strings
                Console.WriteLine(string.Format(Strings.ResultFormat, firstNumber, operation, secondNumber, result));
                Console.WriteLine(string.Format(Strings.Result, result));

            }
            catch (Exception ex)
            {
                // Normally, we'd log this error to a file.
                Console.WriteLine(ex.Message);
            }
        }
    }
}