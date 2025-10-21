using workshop.models;
using workshop.models.builders;

namespace workshop.tests;

public class Tests
{
    [Test]
    public void Test1()
    {
        PersonBuilder builder = new PersonBuilder();
        var person = builder.SetName("nigel").Build();
        Assert.That(person, Is.Not.Null);
        Assert.That(person.Name, Is.EqualTo("nigel"));
        Assert.That(person, Is.TypeOf<Person>());
    }
}
