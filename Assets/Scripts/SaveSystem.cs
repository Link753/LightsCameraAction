using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    #region SAVING
    public static void Save(SaveData Data)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + ("/Image" + Data.imageNo + ".image");
        Debug.Log(path);
        FileStream stream = new(path, FileMode.Create);
        binaryFormatter.Serialize(stream, Data);
        stream.Close();
    }

    public static void Save(PlayerData Data)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + ("/Save.save");
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

    public static PlayerData LoadPlayer()
    {
        BinaryFormatter binaryFormatter = new();
        string path = Application.persistentDataPath + ("/Save.save");
        if (File.Exists(path))
        {
            FileStream fileStream = new(path, FileMode.Open);
            PlayerData PD = binaryFormatter.Deserialize(fileStream) as PlayerData;
            fileStream.Close();
            return PD;
        }
        else
        {
            return null;
        }
    }
    #endregion

    #region MODIFYING

    public static int RemovePhoto(int ImageNo)
    {
        string path = Application.persistentDataPath + ("/Image" + ImageNo + ".image");
        Debug.Log(path);
        if (File.Exists(path))
        {
            File.Delete(path);
            return 1;
        }
        else
        {
            return 0;
        }
    }

    #endregion
}
