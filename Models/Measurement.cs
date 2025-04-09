public class Data
{
    public string Payload { get; set; } = "";
    public bool IsDataValid()
    {
        // Here should be a schema or any other type of check.
        // Otherwise this would be a pirate storage with unchecked .json items.
        return true;
    }
}

public class Measurement
{
    public Data Data {get; set;}
}
