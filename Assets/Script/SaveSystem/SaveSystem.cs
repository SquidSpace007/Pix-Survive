using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    static public Vector3 pos;

    public static void SavePlayer(PlayerMovement player, GameObject _player)
    {
        Debug.Log("Saved " + _player.transform.position);
        pos = _player.transform.position;
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.squidclemeilleur";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/save.squidclemeilleur";
        if (File.Exists(path))
        {
            Debug.Log("Loaded position is  : " + pos);
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file nnot found in " + path);
            return null;
        }
    }
}
