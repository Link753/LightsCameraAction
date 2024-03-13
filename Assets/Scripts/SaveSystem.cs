using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveObject(FloorData floor, bool IsSavingPlayer)
    {
        string path;
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        if(IsSavingPlayer)
        {
            path = Application.persistentDataPath + "PlayerSaves.save";
        }
        else
        {
            path = Application.persistentDataPath + "CameraSaves.save";
        }
        FileStream stream = new FileStream(path, FileMode.Create);
        binaryFormatter.Serialize(stream, floor);
        stream.Close();
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
