namespace console_csv.Models;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Gender { get; set; }
    public string IpAddress { get; set; }
    public int Age { get; set; }


    public static Person Copy(Person person)
    {
        return new Person
        {
            IpAddress = person.IpAddress,
            FirstName = person.FirstName,
            Age = person.Age,
            Email = person.Email,
            Gender = person.Gender, 
            LastName = person.LastName,
            Id = person.Id
        };
    }
}