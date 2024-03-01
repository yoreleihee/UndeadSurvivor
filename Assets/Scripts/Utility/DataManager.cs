using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.U2D;

public static class DataManager
{
    private static List<Enemy> s_enemies;
    public static List<Enemy> Enemies => s_enemies;
    private static List<Bullet> s_bullets;
    public static List<Bullet> Bullets => s_bullets;

    static DataManager()
    {
        Init();
    }

    private static void Init()
    {
        var enemyCsvFile = LoadFile<TextAsset>("Enemy");
        s_enemies = CsvParser.Parse<Enemy>(enemyCsvFile);

        var bulletCsvFile = LoadFile<TextAsset>("Bullet");
        s_bullets = CsvParser.Parse<Bullet>(bulletCsvFile);
    }

    const string DATA_FILE_ROOT_DIRECTORY = "Data";
    private static T LoadFile<T>(string filename) where T : UnityEngine.Object
    {
        var filePath = Path.Combine(DATA_FILE_ROOT_DIRECTORY, filename);

        return Resources.Load<T>(filePath);
    }

    private const string ANIMATOR_FILE_ROOT_DIRECTORY = "Animator";

    public static RuntimeAnimatorController LoadAnimator(string filename)
    {
        var filepath = Path.Combine(ANIMATOR_FILE_ROOT_DIRECTORY, filename);

        return Resources.Load<RuntimeAnimatorController>(filepath);
    }

    private const string SPRITE_FILE_ROOT_DIRECTORY = "Sprites";
    public static SpriteAtlas LoadAtlas(string filename)
    {
        var filepath = Path.Combine(SPRITE_FILE_ROOT_DIRECTORY, filename);

        return Resources.Load<SpriteAtlas>(filepath);
    }
}