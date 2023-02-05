using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveGame()
    {
        var formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/game.dat";

        var stream = new FileStream(path, FileMode.Create);        
        var gameData = new GameData();

        formatter.Serialize(stream, gameData);
        stream.Close();
    }

    public static GameData LoadGame()
    {
        string path = Application.persistentDataPath + "/game.dat";
        if (File.Exists(path))
        {
            var formatter = new BinaryFormatter();
            var stream = new FileStream(path, FileMode.Open);

            var gameData = (GameData)formatter.Deserialize(stream);
            stream.Close();

            return gameData;
        }
        else return null;
    }
}