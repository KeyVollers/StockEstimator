//TODO: Write documentation for header and program intentions
//TODO: Make it so we can save output to a file
//TODO: Make it so we can save input over time calculating larger averages
//        and tracking stocks.
//TODO: Make a check system to make sure stock exists.
//TODO: Try to incorperate a scanning system for stock.

using System;
using System.IO;

namespace StockEstimator
{

  class Program
  {
    public static string getFilePath()
    {
      DateTime today = DateTime.Now;
      string formattedDate = today.ToString("yyyy-MM-dd");
      string fileName = "dataSheet_" + formattedDate + ".txt";
      string filePath = "/Users/keyvollers/Documents/Finance/StockEstimator/StockEstimator/DataSheets/";
      filePath += fileName;
      return filePath;
    }

    public static void Main(string[] args)
    {
      string? stockSymbole;
      string? userInput;

      decimal high;
      decimal low;

      bool isNumber;
      bool newStock = true;

      //Creating new file
      string filePath = getFilePath();
      FileStream fs = File.Create(filePath);
      fs.Close();


      while (newStock)
      {
        Console.Write("\nPlease print the symbole of the stock: ");
        stockSymbole = Console.ReadLine();

        do
        {
          Console.Write("\nPlease write 5-day high value: ");
          userInput = Console.ReadLine();
          isNumber = Decimal.TryParse(userInput, out high);
          if (!isNumber)
          {
            Console.WriteLine("Error, your number was incorrectly written. Please try again...");
          }
        } while (!isNumber);

        do
        {
          Console.Write("\nPlease write 5-day low value: ");
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
          Stock s = new Stock(high, low, stockSymbole);

          s.printStockInfoToTerminal();

          //Asking to write stock to file
          Console.Write("Would you like to write this stock to your Data Sheet? 'y' or 'n': ");
          userInput = Console.ReadLine();
          if (userInput == "y")
          {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
              writer.WriteLine(s);
            }
          }
          //TODO: Needs better error handling for bad user input.
          Console.Write("\nWould you like to continue 'y' or 'n': ");
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