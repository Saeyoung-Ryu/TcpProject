namespace HttpServer.Shared.Common;

public class Column
{
    public string Name { get; set; }
    public string DataType { get; }
    // public int Length { get; } // Add Length property or any other desired properties
    public string StringFormat => $"{Name} ({DataType})"; // Update the string format accordingly

    public Column(string name, string dataType) // Modify constructor accordingly
    {
        Name = name;
        DataType = dataType;
        // Length = length;
    }

    public bool IsEqualTo(Column other)
    {
        return Name == other.Name && DataType == other.DataType; // Update the comparison accordingly
    }
}