using System.Linq.Expressions;

class Program
{
    private enum Options {
        
        help,
        calculate,
        exit
    }
    

  private static void printToUser(string text) {
    Console.WriteLine(text);
  }

  private static string ReadStringFromUser() {
    // obsługa błędów IOException 
    return Console.ReadLine();
  }

  private static void printOptions() {
    int indexCounter = 0;
    foreach (Options option in Enum.GetValues(typeof(Options))) {
        printToUser("" + indexCounter + ". " + option.ToString());
        indexCounter++;
    }
    printToUser("");
    
  }

  private static Options ReadOptionFromUser() {

    while(true) {
        string userInput = ReadStringFromUser();
        if(Enum.IsDefined(typeof(Options), userInput)) {
            return (Options)Enum.Parse(typeof(Options), userInput);   
        } else {
            printToUser("Niepoprawna opcja, wpisz ponownie");
        }
    }
    
    
  }

  private static double CalculateDelta(double a, double b, double c) {
    return Math.Pow(b, 2) - 4 * (a * c);
  }

  private static void CalculateZerosOfFunction() {
    bool exitFlag = false;
    double a = 0;
    double b = 0;
    double c = 0;
    while (exitFlag != true) {
        printToUser("Wpisz argument a:");
        a = double.Parse(ReadStringFromUser());
        if (a == 0) {
            printToUser("Argumnet a nie może się równać 0");
        } else {
            printToUser("Wpisz argument b:");
            b = double.Parse(ReadStringFromUser());
            printToUser("Wpisz argument c:");
            c = double.Parse(ReadStringFromUser());
            double delta = CalculateDelta(a, b, c);
            if(delta < 0) {
                printToUser("Ta funkcja nie ma miejsc zerowych.");
            } else if(delta > 0) {
                double firstFunZero = (-b - Math.Sqrt(delta)) / 2 * a;
                double secondZero = (-b + Math.Sqrt(delta)) / 2 * a;
                double firstZeroTrancuated = Math.Truncate(firstFunZero * 100) / 100;
                double secondZeroTrancuated = Math.Truncate(secondZero * 100) / 100;
                printToUser("Pierwsze miejsce zerowe: " + String.Format("{0:#.##}", firstZeroTrancuated));
                printToUser("Drugie miejsce zerowe: " + String.Format("{0:#.##}", secondZeroTrancuated));
            } else {
                double funZero = -b / 2 * a;
                double funZeroTrancuated = Math.Truncate(funZero * 100) / 100;
                printToUser("Funkcja ma tylko jedno miejsce zerowe: " + String.Format("{0:#.##}", funZeroTrancuated));
            }
            exitFlag = true;

        }
    }
    

  }

  private static void ExitProgramm() {
    printToUser("koniec programu bye bye!");
    
  }

  private static void PrintHelpToUser() {
    printToUser("""
        Celem tego programu jest obliczanie miejsc zerowych funkcji kwadratowej.
        Aby rozpocząć wpisz opcję calculate.
        Następnie wpisz argumenty a, b i c.
        Pamietaj, że argument a nie może być równy 0.
        """);
  }

  private static void MainLoop() {
    
    bool exitLoop = false;

    while(exitLoop != true) {
        printToUser("Dostępne opcje:");
        printOptions();
        printToUser("Wprowadz opcję...");
        Options userOption = ReadOptionFromUser();
        switch(userOption) {
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

