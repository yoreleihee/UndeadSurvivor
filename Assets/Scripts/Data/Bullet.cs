using CsvHelper.Configuration.Attributes;

public class Bullet
{
    [Index(0)] public int Id;
    [Index(1)] public string SpriteName  { get; set; }
    [Index(2)] public float Damage { get; set; }
    [Index(3)] public float Pierce { get; set; }

}