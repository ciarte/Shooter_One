using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public Button exitButton;
    public AudioMixerSnapshot pauseSNP, gameSNP;
    

    private void Awake()
    {
        pauseMenu.SetActive(false);
        exitButton.onClick.AddListener(ExitGame);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            pauseSNP.TransitionTo(0.1f);

           
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        gameSNP.TransitionTo(0.1f);
    }

    private void ExitGame()
    {
        print("Ejecucion finalizada");
        Application.Quit();
    }

}
