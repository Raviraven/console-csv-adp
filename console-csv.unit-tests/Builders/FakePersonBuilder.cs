using Bogus;
using Person = console_csv.Models.Person;

namespace console_csv.unit_tests.Builders;

public class FakePersonBuilder
{
    private static Faker<Person> EntityFaker
    {
        get
        {
            return new Faker<Person>()
                .RuleFor(n => n.Id, b => b.Random.Int(0, 100))
                .RuleFor(n => n.IpAddress, b => b.Internet.IpAddress().ToString())
                .RuleFor(n => n.FirstName, b => b.Name.FirstName())
                .RuleFor(n => n.LastName, b => b.Name.LastName())
                .RuleFor(n => n.Age, b => b.Random.Int(0, 100))
                .RuleFor(n => n.Email, b => b.Internet.Email())
                .RuleFor(n => n.Gender, b => b.Person.Gender.ToString());
        }
    }

    private readonly Person _entity;

    public FakePersonBuilder()
    {
        _entity = EntityFaker.Generate();
    }

    public FakePersonBuilder WithAge(int age)
    {
        _entity.Age = age;
        return this;
    }

    public FakePersonBuilder WithGender(string gender)
    {
        _entity.Gender = gender;
        return this;
    }

    public Person Build() => _entity;

    public List<Person> BuildList(int count) => EntityFaker.Generate(count);
}