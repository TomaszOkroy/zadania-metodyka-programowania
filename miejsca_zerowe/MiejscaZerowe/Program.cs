using System.Linq.Expressions;

class Program
{
  private enum Options
  {

    help,
    calculate,
    exit
  }


  private static void PrintToUser(string text)
  {
    Console.WriteLine(text);
  }

  private static string ReadStringFromUser()
  {
    string? line = Console.ReadLine();
    if (line is not null)
    {
      return line;
    }
    else
    {
      return "0";
    }
  }

  private static double ReadDoubleFromUser()
  {
    while (true)
    {
      try
      {
        double number = double.Parse(ReadStringFromUser());
        return number;

      }
      catch (FormatException e)
      {
        PrintToUser("Nieprawidłowy format danych wpisz liczbę ponownie");
        PrintToUser(e.Message);
      }
    }
  }

  private static void PrintOptions()
  {
    int indexCounter = 0;
    foreach (Options option in Enum.GetValues(typeof(Options)))
    {
      PrintToUser("" + indexCounter + ". " + option.ToString());
      indexCounter++;
    }
    PrintToUser("");

  }

  private static Options ReadOptionFromUser()
  {

    while (true)
    {
      string userInput = ReadStringFromUser();
      if (Enum.IsDefined(typeof(Options), userInput))
      {
        return (Options)Enum.Parse(typeof(Options), userInput);
      }
      else
      {
        PrintToUser("Niepoprawna opcja, wpisz ponownie");
      }
    }


  }

  private static double CalculateDelta(double a, double b, double c)
  {
    return Math.Pow(b, 2) - 4 * (a * c);
  }

  private static void CalculateZerosOfFunction()
  {
    bool exitFlag = false;
    double a = 0;
    double b = 0;
    double c = 0;
    while (exitFlag != true)
    {
      PrintToUser("Wpisz argument a:");
      a = ReadDoubleFromUser();
      if (a == 0)
      {
        PrintToUser("Argumnet a nie może się równać 0");
      }
      else
      {
        PrintToUser("Wpisz argument b:");
        b = ReadDoubleFromUser();
        PrintToUser("Wpisz argument c:");
        c = ReadDoubleFromUser();
        double delta = CalculateDelta(a, b, c);
        if (delta < 0)
        {
          PrintToUser("Ta funkcja nie ma miejsc zerowych.");
        }
        else if (delta > 0)
        {
          double firstFunZero = (-b - Math.Sqrt(delta)) / 2 * a;
          double secondZero = (-b + Math.Sqrt(delta)) / 2 * a;
          double firstZeroTrancuated = Math.Truncate(firstFunZero * 100) / 100;
          double secondZeroTrancuated = Math.Truncate(secondZero * 100) / 100;
          PrintToUser("Pierwsze miejsce zerowe: " + String.Format("{0:#.##}", firstZeroTrancuated));
          PrintToUser("Drugie miejsce zerowe: " + String.Format("{0:#.##}", secondZeroTrancuated));
        }
        else
        {
          double funZero = -b / 2 * a;
          double funZeroTrancuated = Math.Truncate(funZero * 100) / 100;
          PrintToUser("Funkcja ma tylko jedno miejsce zerowe: " + String.Format("{0:#.##}", funZeroTrancuated));
        }
        exitFlag = true;

      }
    }


  }

  private static void ExitProgramm()
  {
    PrintToUser("koniec programu bye bye!");

  }

  private static void PrintHelpToUser()
  {
    PrintToUser("""
        Celem tego programu jest obliczanie miejsc zerowych funkcji kwadratowej.
        Aby rozpocząć wpisz opcję calculate.
        Następnie wpisz argumenty a, b i c.
        Pamietaj, że argument a nie może być równy 0.
        """);
  }

  private static void MainLoop()
  {

    bool exitLoop = false;

    while (exitLoop != true)
    {
      PrintToUser("Dostępne opcje:");
      PrintOptions();
      PrintToUser("Wprowadz opcję...");
      Options userOption = ReadOptionFromUser();
      switch (userOption)
      {
        case Options.help:
          PrintHelpToUser();
          break;
        case Options.calculate:
          CalculateZerosOfFunction();
          break;
        case Options.exit:
          exitLoop = true;
          ExitProgramm();
          break;

      }



    }
  }

  static void Main(string[] args)
  {

    Console.WriteLine("Witaj w programie do oblicznia miejsc zerowaych funkcji kwadratowej!\n");
    MainLoop();
  }
}

