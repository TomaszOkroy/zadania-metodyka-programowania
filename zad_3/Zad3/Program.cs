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

    private static int[] SortArray(int[] numberArray)
    {
        var n = numberArray.Length;

        for (int i = 0; i < n - 1; i++)
            for (int j = 0; j < n - i - 1; j++)
                if (numberArray[j] > numberArray[j + 1])
                {
                    int tempVar = numberArray[j];
                    numberArray[j] = numberArray[j + 1];
                    numberArray[j + 1] = tempVar;
                }

        return numberArray;
    }

    private static int[] FillArrayWithRandomNum(int arrayLength)
    {
        int min = 0;
        int max = 99;
        Random rng = new Random();
        int[] randomArray = new int[arrayLength];



        for (int i = 0; i < randomArray.Length; i++)
        {
            randomArray[i] = min + (rng.Next() % (max + 1 - min));
        }
        return randomArray;
    }


    static void Main(string[] args)
    {

        PrintToUser("Podaj wielkość tablicy:");
        int length = ReadIntFromUser();
        int[] radomIntsFomRange = FillArrayWithRandomNum(length);
        PrintToUser("\nTablica:");
        for (var i = 0; i < length; i++)
        {
            PrintToUser(radomIntsFomRange[i].ToString());
        }

        PrintToUser("\nPosortowana tablica z wykożystaniem algorytmu Bubble sort:");
        int[] sortedArray = SortArray(radomIntsFomRange);

        for (var i = 0; i < sortedArray.Length; i++)
        {
            PrintToUser(sortedArray[i].ToString());
        }

    }
}

