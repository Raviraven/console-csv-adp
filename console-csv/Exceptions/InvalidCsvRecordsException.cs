namespace console_csv.Exceptions;

public class InvalidCsvRecordsException : Exception
{
    public InvalidCsvRecordsException() : base("Cannot properly read csv file.")
    {
    }
}