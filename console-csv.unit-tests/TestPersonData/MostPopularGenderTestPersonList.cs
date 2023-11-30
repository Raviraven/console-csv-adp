using System.Collections;
using console_csv.Models;
using console_csv.unit_tests.Builders;

namespace console_csv.unit_tests.TestPersonData;

public class MostPopularGenderTestPersonList : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return SinglePerson;
        yield return MultiplePerson;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private static readonly object[] SinglePerson =
    {
        new List<Person> { new FakePersonBuilder().WithGender("Female").Build() }, "Female",
    };

    private static readonly object[] MultiplePerson =
    {
        new List<Person>
        {
            new FakePersonBuilder().WithGender("Female").Build(),
            new FakePersonBuilder().WithGender("Male").Build(),
            new FakePersonBuilder().WithGender("Prefer not to say").Build(),
            new FakePersonBuilder().WithGender("Female").Build(),
            new FakePersonBuilder().WithGender("Prefer not to say").Build(),
            new FakePersonBuilder().WithGender("Prefer not to say").Build(),
        },
        "Prefer not to say"
    };
}