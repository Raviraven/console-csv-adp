using console_csv.Exceptions;
using console_csv.Services;
using console_csv.Utils;

namespace console_csv;

public static class Program
{
    private static readonly ICsvService CsvService;

    static Program()
    {
        CsvService = new CsvService(new CsvReader());
    }
    
    public static void Main()
    {
        var filePath = Environment.CurrentDirectory + "/data.csv";

        try
        {
            var people = CsvService.ReadPersonDataFromCsvFile(filePath);
            var averageAge = CsvService.GetAverageAge(people);
            var mostPopularGender = CsvService.GetMostPopularGender(people);

            Console.WriteLine($"Average age: {averageAge}");
            Console.WriteLine($"The most popular gender: {mostPopularGender}");
            Console.WriteLine($"No. of records: {people.Count()}");
        }
        catch (InvalidCsvRecordsException ex)
        {
            ConsoleExtended.WriteError(ex.Message);
        }
        catch (Exception ex)
        {
            ConsoleExtended.WriteError(ex.Message);
        }

    }
}
