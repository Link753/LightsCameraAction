using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] Values value;
    int[] data;
    Transform player; 
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void Save()
    {
        data = value.GetValues();
        player = value.GetPlayer();
        PlayerData PD = new(data[0], data[1], data[2], player);
        SaveSystem.Save(PD);
    }

    public void SaveAndQuit()
    {
        Save();
        Application.Quit();
    }
}
