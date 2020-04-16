using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void saveData(int level) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/game_data.president"; //path will not change no matter the platform using persistent
        FileStream stream = new FileStream(path, FileMode.Create); // creates file on system specified by path

        GameData data = new GameData(level);

        formatter.Serialize(stream, data); //writes data to file

        stream.Close();

        Debug.Log(path.ToString());
    }

    public static GameData loadData() {

        string path = Application.persistentDataPath + "/game_data.president"; //path will not change no matter the platform using persistent
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            GameData data = (GameData)formatter.Deserialize(stream);
            stream.Close();
            return data;
        }
        else {
            Debug.Log("File not found in " + path.ToString());
            return null;
        }

    }

    public static void EraseSaveData() {
        string path = Application.persistentDataPath + "/game_data.president"; //path will not change no matter the platform using persistent
        if (File.Exists(path))
            File.Delete(path);
    }
}
