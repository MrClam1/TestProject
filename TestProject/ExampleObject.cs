namespace TestProject;

public class ExampleObject
{
    public string Name { get; private set; }

    public ExampleObject(string name)
    {
        Name = name;
    }

    public void SetName(string name)
    {
        Name = name;
    }
    
    ~ExampleObject()
    {
        Console.WriteLine($"Destructor called for ExampleObject with name: {Name}");
    }
}