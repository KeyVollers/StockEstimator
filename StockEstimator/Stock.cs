//This will be the base of the stock object used in original program

using System;

namespace StockEstimator;

public class Stock
{
  private decimal average;
  private decimal buy;
  private decimal sell;

  public decimal High { private set; get; }
  public decimal Low { private set; get; }
  public decimal Average
  {
    get { return average; }
    private set
    {
      average = (this.High + this.Low) / 2;
    }
  }
  public decimal Buy
  {
    get { return buy; }
    private set
    {
      buy = this.Average - (this.High + this.Low) / 4;
    }
  }
  public decimal Sell
  {
    get { return sell; }
    private set
    {
      sell = this.Average + (this.High + this.Low) / 4;
    }
  }
  public string Name { private set; get; }

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
  }

  public void printStockInfoToTerminal()
  {
    Console.WriteLine("\n" + this.Name);
    Console.WriteLine($"\tHigh     |\t${Math.Round(this.High, 2)}");
    Console.WriteLine($"\tLow      |\t${Math.Round(this.Low, 2)}");
    Console.WriteLine($"\tAverage  |\t${Math.Round(this.Average, 2)}");
    Console.WriteLine($"\tBuy      |\t${Math.Round(this.Buy, 2)}");
    Console.WriteLine($"\tSell     |\t${Math.Round(this.Sell, 2)}\n");
  }

}