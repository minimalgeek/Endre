using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoad
{
    private const string FILE_PATH = "/louderThanHell.gd";

    public static void Save(GameData data)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + FILE_PATH);
        bf.Serialize(file, data);
        file.Close();
    }

    public static GameData Load()
    {
        if (File.Exists(Application.persistentDataPath + FILE_PATH))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + FILE_PATH, FileMode.Open);
            GameData data = (GameData)bf.Deserialize(file);
            file.Close();

            PostRead(data);

            return data;
        }

        return new GameData();
    }

    private static void PostRead(GameData data)
    {
        data.SortBestScores();
    }
}
