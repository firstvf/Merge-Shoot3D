using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    private static GameData _gameData = null;

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
        if (_gameData != null)
            return _gameData;

        string path = Application.persistentDataPath + "/game.dat";
        if (File.Exists(path))
        {
            var formatter = new BinaryFormatter();
            var stream = new FileStream(path, FileMode.Open);

            var gameData = (GameData)formatter.Deserialize(stream);
            stream.Close();
            _gameData = gameData;

            return gameData;
        }
        else return null;
    }
}