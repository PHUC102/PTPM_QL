// Controller: PersonController.cs
public class PersonController
{
    private Person _person;

    public PersonController()
    {
        _person = new Person();
    }

    public void SetPersonData(string name, int age)
    {
        _person.Name = name;
        _person.Age = age;
    }

    public Person GetPersonData()
    {
        return _person;
    }
}
