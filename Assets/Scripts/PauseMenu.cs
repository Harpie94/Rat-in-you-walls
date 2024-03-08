using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{


    public static bool isPaused = false;
    public bool J1Victory = false;
    public bool J2Victory = false;
    public bool Tie = false;
    public GameObject PauseMenuUI;
    public GameObject VictoireJ1;
    public GameObject VictoireJ2;
    public GameObject Egalité;
    public string MainMenuSceneName;
    public string SceneJeuName;

    private void Start()
    {
        VictoireJ1.SetActive(false);
        VictoireJ2.SetActive(false);
        Egalité.SetActive(false);
    
}
    // Update is called once per frame
    void Update()
    {
        if (!J1Victory && !J2Victory && !Tie)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused)
                {
                    Resume();

                }
                else
                {
                    Pause();
                }
            }
        }else if (J1Victory)
        {
            VictoryPrintJ1();
        }
        else if (J2Victory)
        {
            VictoryPrintJ2();
        }
        else if (Tie)
        {
            TiedPrint();
        }
    }

    public void Rejouer()
    {
        Debug.Log("Rejouer");
        SceneManager.LoadScene(SceneJeuName);
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Menu");
        SceneManager.LoadScene(MainMenuSceneName);
    }

    public void QuitGame()
    {
        Debug.Log("Quitter");
        Application.Quit();
    }

    public void VictoryPrintJ1()
    {
        VictoireJ1.SetActive(true);
        Time.timeScale = 0f;
    }

    public void VictoryPrintJ2()
    {
        VictoireJ2.SetActive(true);
        Time.timeScale = 0f;
    }

    public void TiedPrint()
    {
        Egalité.SetActive(true);
        Time.timeScale = 0f;
    }
}

