using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    #region SAVING
    public static void Save(SaveData Data, bool isSavingPlayer)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path;
        if (isSavingPlayer)
        {
            path = Application.persistentDataPath + "/PlayerSaves.save";
        }
        else
        {
            path = Application.persistentDataPath + ("/Image" + Data.imageNo + ".image");
        }
        Debug.Log(path);
        FileStream stream = new(path, FileMode.Create);
        binaryFormatter.Serialize(stream, Data);
        stream.Close();
    }
    #endregion

    #region LOADING
    public static FloorData LoadPicture(int ImageNo)
    {
        BinaryFormatter binaryParser = new BinaryFormatter();
        string path = Application.persistentDataPath + ("/Image" + ImageNo + ".image");
        Debug.Log(path);
        if (File.Exists(path))
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
