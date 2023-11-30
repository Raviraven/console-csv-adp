using System.Globalization;
using CsvHelper.Configuration;

namespace console_csv.Services;

public interface ICsvReader
{
    IEnumerable<T> ReadRecordsFromFile<T, TMapper>(string filePath)
        where TMapper : ClassMap<T>;
} 

public class CsvReader : ICsvReader
{
    public IEnumerable<T> ReadRecordsFromFile<T, TMApper>(string filePath) where TMApper : ClassMap<T>
    {
        using (var reader = new StreamReader(filePath))
        {
            using (var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<TMApper>();
                return csv.GetRecords<T>().ToList();
            }
        }
    }
}