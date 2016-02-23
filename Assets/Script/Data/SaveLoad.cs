using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoad
{
    private const string FILE_PATH = "/louderThanHell.gd";

    public static GameData data;

    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + FILE_PATH);
        bf.Serialize(file, data);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + FILE_PATH))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + FILE_PATH, FileMode.Open);
            data = (GameData)bf.Deserialize(file);
            file.Close();

            PostRead(data);
        } else
        {
            data = new GameData();
        }
        
    }

    private static void PostRead(GameData data)
    {
        data.SortBestScores();
    }
}
