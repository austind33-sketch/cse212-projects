using System.Text.Json.Serialization;
// Problem 5 classes
public class FeatureCollection
{
    [JsonPropertyName("features")]
    public Feature[] Features { get; set; }
}

public class Feature
{
    [JsonPropertyName("properties")]
    public Properties Properties { get; set; }
}

public class Properties
{
    [JsonPropertyName("place")]
    public string Place { get; set; }

    [JsonPropertyName("mag")]
    public double Mag { get; set; }
}