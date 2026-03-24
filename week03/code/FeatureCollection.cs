public class FeatureCollection
{
    public List<Feature> Features { get; set; } = [];
}

public class Feature
{
    public FeatureProperties Properties { get; set; } = new();
}

public class FeatureProperties
{
    public string Place { get; set; } = "";
    public decimal? Mag { get; set; }
}