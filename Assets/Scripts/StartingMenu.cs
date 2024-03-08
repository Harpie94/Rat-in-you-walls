using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public string SceneJeuName;

    public void StartGame()
    {
        Debug.Log("Menu");
        SceneManager.LoadScene(SceneJeuName);
        Time.timeScale = 1f;
    }

    public void QuitGameMenu()
    {
        Debug.Log("Quitter");
        Application.Quit();
    }
}
