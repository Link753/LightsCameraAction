using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(SaveData PlayerData)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "PlayerSaves.save";
        FileStream stream = new(path, FileMode.Create);
        binaryFormatter.Serialize(stream, PlayerData);
        stream.Close();
    }

    public static void SavePicture()
    {

    }

    public static void LoadObjects(bool IsLoadingPlayer)
    {
        string path;
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        if(IsLoadingPlayer)
        {
            path = Application.persistentDataPath + "PlayerSaves.save";
        }
        else
        {
            path = Application.persistentDataPath + "CameraSaves.save";
        }
    }
}
