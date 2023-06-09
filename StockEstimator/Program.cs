//TODO: Write documentation for header and program intentions
//TODO: Convert Symple Program To Object Oriented
//TODO: Make it so we can save output to a file
//TODO: Make it so we can save input over time calculating larger averages
//        and tracking stocks.
//TODO: Make a check system to make sure stock exists.
//TODO: Try to incorperate a scanning system for stock.

using System;

namespace StockEstimator
{
  class Program
  {
    public static void Main(string[] args)
    {
      string? stockSymbole;
      string? userInput;

      decimal high;
      decimal low;
      decimal average;
      decimal buy;
      decimal sell;

      bool isNumber;
      bool newStock = true;

      while (newStock)
      {
        Console.Write("\nPlease print the symbole of the stock: ");
        stockSymbole = Console.ReadLine();

        do
        {
          Console.Write("\nPlease write month high value: ");
          userInput = Console.ReadLine();
          isNumber = Decimal.TryParse(userInput, out high);
          if (!isNumber)
          {
            Console.WriteLine("Error, your number was incorrectly written. Please try again...");
          }
        } while (!isNumber);

        do
        {
          Console.Write("\nPlease write month low value: ");
          userInput = Console.ReadLine();
          isNumber = Decimal.TryParse(userInput, out low);
          if (!isNumber)
          {
            Console.WriteLine("Error, your number was incorrectly written. Please try again...");
          }
        } while (!isNumber);

        if (high <= low)
        {
          Console.WriteLine("Error, your high value is greater or equal to your low value. Please try again...");
        }
        else
        {
          average = (high - low) / 2 + low;
          buy = average - ((high - low) / 4);
          sell = average + ((high - low) / 4);

          high = Math.Round(high, 2);
          low = Math.Round(low, 2);
          average = Math.Round(average, 2);
          buy = Math.Round(buy, 2);
          sell = Math.Round(sell, 2);

          Console.WriteLine("\n" + stockSymbole);
          Console.WriteLine($"\tHigh     |\t${high}");
          Console.WriteLine($"\tLow      |\t${low}");
          Console.WriteLine($"\tAverage  |\t${average}");
          Console.WriteLine($"\tBuy      |\t${buy}");
          Console.WriteLine($"\tSell     |\t${sell}\n");

          //TODO: Needs better error handling for bad user input.
          Console.Write("Would you like to continue 'y' or 'n': ");
          userInput = Console.ReadLine();
          if (userInput == "n")
          {
            newStock = false;
          }
        }
      }
    }
  }
}