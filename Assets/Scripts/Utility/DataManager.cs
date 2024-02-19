using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class DataManager
{
    private static List<Enemy> s_enemies;
    public static List<Enemy> Enemies => s_enemies;

    static DataManager()
    {
        Init();
    }

    private static void Init()
    {
        var enemyCsvFile = LoadFile<TextAsset>("Enemy");
        s_enemies = CsvParser.Parse<Enemy>(enemyCsvFile);
    }

    const string DATA_FILE_ROOT_DIRECTORY = "Data";
    private static T LoadFile<T>(string filename) where T : UnityEngine.Object
    {
        var filePath = Path.Combine(DATA_FILE_ROOT_DIRECTORY, filename);

        return Resources.Load<T>(filePath);
    }
}