using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public bool PauseMenu = false;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && PauseMenu)
        {
            Pause();
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene("village");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Save Logs");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Pause()
    {

        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
            GetComponent<Canvas>().enabled = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1;
            GetComponent<Canvas>().enabled = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
