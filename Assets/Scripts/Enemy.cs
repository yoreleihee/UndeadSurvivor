using CsvHelper.Configuration.Attributes;

public class Enemy
{
    [Index(0)]
    public int Id { get; set; }
    [Index(1)]
    public string SpriteName { get; set; }
    [Index(2)]
    public float Speed { get; set; }
    [Index(3)]
    public float Health { get; set; }
    [Index(4)]
    public string Animator { get; set; }
    [Index(5)]
    public float SpawnTime { get; set; }
}