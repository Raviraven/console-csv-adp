using console_csv.Exceptions;
using console_csv.Mappers;
using console_csv.Services;
using console_csv.unit_tests.Builders;
using console_csv.unit_tests.TestPersonData;
using Person = console_csv.Models.Person;

namespace console_csv.unit_tests;

public class CsvServiceTests
{
    private readonly CsvService _sut;
    private readonly ICsvReader _csvReader;
    private readonly string _filePathMock;

    public CsvServiceTests()
    {
        _csvReader = Substitute.For<ICsvReader>();
        _sut = new CsvService(_csvReader);
        _filePathMock = "test-path.csv";
    }


    [Fact]
    public void ReadPersonDataFromCsvFile_Should_ReturnReadRecords()
    {
        var recordsMock = new FakePersonBuilder().BuildList(4);

        _csvReader.ReadRecordsFromFile<Person, PersonMapper>(_filePathMock).Returns(recordsMock);

        var result = _sut.ReadPersonDataFromCsvFile(_filePathMock);

        result.Should().BeEquivalentTo(new[]
        {
            Person.Copy(recordsMock[0]),
            Person.Copy(recordsMock[1]),
            Person.Copy(recordsMock[2]),
            Person.Copy(recordsMock[3]),
        });
    }

    [Fact]
    public void ReadPersonDataFromCsvFile_Should_ThrowWhenRecordsAreNull()
    {
        _csvReader.ReadRecordsFromFile<Person, PersonMapper>(_filePathMock).Returns((IEnumerable<Person>)null!);

        _sut.Invoking(n => n.ReadPersonDataFromCsvFile(_filePathMock))
            .Should()
            .ThrowExactly<InvalidCsvRecordsException>();
    }

    [Theory]
    [ClassData(typeof(AverageAgeTestPersonList))]
    public void GetAverageAge_Should_ReturnAveragePersonAge(IEnumerable<Person> people, int expectedAverageAge)
    {
        var result = _sut.GetAverageAge(people);
        result.Should().Be(expectedAverageAge);
    }

    [Fact]
    public void GetAverageAge_Should_ReturnZeroWhenEmptyArray()
    {
        _sut.GetAverageAge(Enumerable.Empty<Person>()).Should().Be(0);
    }

    [Theory]
    [ClassData(typeof(MostPopularGenderTestPersonList))]
    public void GetMostPopularGender_Should_ReturnMostPopularGender(IEnumerable<Person> people, string expectedGender)
    {
        var result = _sut.GetMostPopularGender(people);
        result.Should().Be(expectedGender);
    }

    [Fact]
    public void GetMostPopularGender_Should_ReturnAllGendersWithTheHighestAppearanceWhenItsEqual()
    {
        var people = new List<Person>
        {
            new FakePersonBuilder().WithGender("Female").Build(),
            new FakePersonBuilder().WithGender("Male").Build(),
            new FakePersonBuilder().WithGender("Prefer not to say").Build()
        };
        
        var expectedResult = "Female, Male, Prefer not to say";

        var result = _sut.GetMostPopularGender(people);

        result.Should().Be(expectedResult);
    }
    
    
}