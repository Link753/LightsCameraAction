using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] GameObject ContinueGameButton;
    string path;
    // Start is called before the first frame update
    void Start()
    {
        path = Application.persistentDataPath + "/Save.save";
        if (!File.Exists(path))
        {
            ContinueGameButton.SetActive(false);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void NewGame()
    {
        File.Delete(path);
        SceneManager.LoadScene(1);
    }
}
