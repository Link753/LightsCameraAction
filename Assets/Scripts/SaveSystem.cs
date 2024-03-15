using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    #region SAVING
    public static void SavePlayer(SaveData PlayerData)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "PlayerSaves.save";
        FileStream stream = new(path, FileMode.Create);
        binaryFormatter.Serialize(stream, PlayerData);
        stream.Close();
    }
    public static void SavePicture(FloorData data, int ImageNo)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + ("/Image" + ImageNo + ".image");
        Debug.Log(path);
        FileStream stream = new(path, FileMode.Create);
        binaryFormatter.Serialize(stream, data);
        stream.Close();
    }
    #endregion

    #region LOADING
    public static FloorData LoadPicture(int ImageNo)
    {
        BinaryFormatter binaryParser = new BinaryFormatter();
        string path = Application.persistentDataPath + ("/Image" + ImageNo + ".image");
        if(path != null)
        {
            FileStream stream = new(path, FileMode.Open);
            FloorData FD = binaryParser.Deserialize(stream) as FloorData;
            stream.Close();
            return FD;
        }
        else
        {
            return null;//code this to return NO IMAGE file as unknown how unity will handle this
        }
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
    #endregion
}
