//This will be the base of the stock object used in original program

using System;

namespace StockEstimator;

public class Stock
{
  public Stock(decimal high, decimal low, string? name)
  {
    this.High = high;
    this.Low = low;

    //if there is no name
    if (name == null)
    {
      this.Name = "Unknown";
    }
    else
    {
      this.Name = name;
    }

    this.Average = (this.High - this.Low) / 2 + this.Low;
    this.Buy = this.Average - (this.High - this.Low) / 4;
    this.Sell = this.Average + (this.High - this.Low) / 4;

  }

  public decimal High { private set; get; }
  public decimal Low { private set; get; }
  public decimal Average { private set; get; }
  public decimal Buy { private set; get; }
  public decimal Sell { private set; get; }
  public string Name { private set; get; }
  public decimal totalStockValue { set; get; }
  public int numShares { set; get; }
  public int valuePerShare { set; get; }

  public void printStockInfoToTerminal()
  {
    Console.WriteLine("\n" + this.Name);
    Console.WriteLine($"\tHigh     |\t${Math.Round(this.High, 2)}");
    Console.WriteLine($"\tLow      |\t${Math.Round(this.Low, 2)}");
    Console.WriteLine($"\tAverage  |\t${Math.Round(this.Average, 2)}");
    Console.WriteLine($"\tBuy      |\t${Math.Round(this.Buy, 2)}");
    Console.WriteLine($"\tSell     |\t${Math.Round(this.Sell, 2)}\n");
  }

  public override string ToString()
  {
    string fullStockInfo = this.Name;
    fullStockInfo += $"\n\tHigh     |\t${Math.Round(this.High, 2)}";
    fullStockInfo += $"\n\tLow      |\t${Math.Round(this.Low, 2)}";
    fullStockInfo += $"\n\tAverage  |\t${Math.Round(this.Average, 2)}";
    fullStockInfo += $"\n\tBuy      |\t${Math.Round(this.Buy, 2)}";
    fullStockInfo += $"\n\tSell     |\t${Math.Round(this.Sell, 2)}\n";
    return fullStockInfo;
  }
}