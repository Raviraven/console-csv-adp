using console_csv.Models;
using CsvHelper.Configuration;

namespace console_csv.Mappers;

public sealed class PersonMapper : ClassMap<Person>
{
    public PersonMapper()
    {
        Map(n => n.Id).Name("id");
        Map(n => n.FirstName).Name("first_name");
        Map(n => n.LastName).Name("last_name");
        Map(n => n.Email).Name("email");
        Map(n => n.Gender).Name("gender");
        Map(n => n.IpAddress).Name("ip_address");
        Map(n => n.Age).Name("age");
    }
}
