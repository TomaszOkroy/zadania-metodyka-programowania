using System.Linq.Expressions;

class Program
{

    private static void PrintToUser(string text)
    {
        Console.WriteLine(text);
    }

    private static string ReadStringFromUser()
    {
        while (true)
        {

            string? result = Console.ReadLine();
            if (result is not null)
            {
                return result;
            }


        }

    }

    private static int ReadIntFromUser()
    {
        while (true)
        {
            try
            {
                int number = int.Parse(ReadStringFromUser());
                return number;

            }
            catch (FormatException e)
            {
                PrintToUser("Nieprawidłowy format danych wpisz liczbę ponownie");
                PrintToUser(e.Message);
            }
        }

    }

    static void Main(string[] args)
    {

        PrintToUser("Podaj liczbę rozpoczynającą ciąg:");
        int start = ReadIntFromUser();
        PrintToUser("Podaj liczbę kończącą ciąg:");
        int end = ReadIntFromUser();
        PrintToUser("Ciąg liczb od:" + start + " do:" + end);
        for (int i = start; i <= end; i++)
        {
            PrintToUser(i.ToString());
        }

    }
}

