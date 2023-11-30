using System.Collections;
using console_csv.Models;
using console_csv.unit_tests.Builders;

namespace console_csv.unit_tests.TestPersonData;

public class AverageAgeTestPersonList : IEnumerable<object[]>
{
    private static readonly object[] SinglePerson =
    {
        new List<Person>
        {
            new FakePersonBuilder().WithAge(26).Build()
        },
        26
    };

    private static readonly object[] PersonWithDecimal3 =
    {
        new List<Person>
        {
            new FakePersonBuilder().WithAge(26).Build(),
            new FakePersonBuilder().WithAge(1).Build(),
            new FakePersonBuilder().WithAge(1).Build(),
        },
        9
    };

    private static readonly object[] PersonWithDecimal5 =
    {
        new List<Person>
        {
            new FakePersonBuilder().WithAge(26).Build(),
            new FakePersonBuilder().WithAge(73).Build(),
            new FakePersonBuilder().WithAge(4).Build(),
            new FakePersonBuilder().WithAge(15).Build()
        },
        30
    };

    public IEnumerator<object[]> GetEnumerator()
    {
        yield return SinglePerson;
        yield return PersonWithDecimal3;
        yield return PersonWithDecimal5;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}