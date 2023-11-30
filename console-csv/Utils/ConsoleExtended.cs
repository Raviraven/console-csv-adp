namespace console_csv.Utils;

public static class ConsoleExtended
{
    public static void WriteError(string error)
    {
        var oldColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(error);
        Console.ForegroundColor = oldColor;
    }
}