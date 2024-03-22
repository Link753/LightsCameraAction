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
    public static SaveData LoadPicture(int ImageNo)
    {
        BinaryFormatter binaryParser = new BinaryFormatter();
        string path = Application.persistentDataPath + ("/Image" + ImageNo + ".image");
        if (File.Exists(path))
        {
            FileStream stream = new(path, FileMode.Open);
            SaveData SD = binaryParser.Deserialize(stream) as SaveData;
            stream.Close();
            return SD;
        }
        else
        {
            return null;
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
