using console_csv.Exceptions;
using console_csv.Mappers;
using console_csv.Models;

namespace console_csv.Services;

public interface ICsvService
{
    IEnumerable<Person> ReadPersonDataFromCsvFile(string filePath);
    int GetAverageAge(IEnumerable<Person> people);
    string GetMostPopularGender(IEnumerable<Person> people);
}

public class CsvService : ICsvService
{
    private readonly ICsvReader _csvReader;

    public CsvService(ICsvReader csvReader)
    {
        _csvReader = csvReader;
    }

    public IEnumerable<Person> ReadPersonDataFromCsvFile(string filePath)
    {
        var records = _csvReader.ReadRecordsFromFile<Person, PersonMapper>(filePath);

        if (records is null)
        {
            throw new InvalidCsvRecordsException();
        }

        return records;
    }

    public int GetAverageAge(IEnumerable<Person> people)
    {
        if (!people.Any())
        {
            return 0;
        }

        var avg = people.Average(n => n.Age);
        return (int)Math.Round(avg);
    }

    public string GetMostPopularGender(IEnumerable<Person> people)
    {
        var pplGroupedByGender = people
            .GroupBy(n => n.Gender)
            .Select(n => new
            {
                gender = n.Key,
                count = n.Count()
            });

        var mostPopularGender = pplGroupedByGender.MaxBy(n => n.count);
        var allPopularGenders = pplGroupedByGender
            .Where(n => n.count == mostPopularGender.count)
            .Select(n => n.gender);

        if (allPopularGenders.Count() > 1)
        {
            return string.Join(", ", allPopularGenders);
        }

        return mostPopularGender.gender;
    }
}