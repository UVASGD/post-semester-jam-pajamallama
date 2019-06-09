using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    string menuSceneName = "Menu";

    public static bool GamePaused = false;

    CursorLockMode previousMode = CursorLockMode.None;

    private void Start()
    {
        PlayerController.instance.Pause += Toggle;
    }

    void Toggle()
    {
        if (GamePaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        SetUIActive(false);
        GamePaused = false;
        Time.timeScale = 1f;
        RevertCursor();
    }

    public void Pause()
    {
        SetUIActive(true);
        GamePaused = true;
        Time.timeScale = 0f;
        FreeCursor();
    }

    public void Menu()
    {
        SceneManager.LoadScene(menuSceneName);
    }

    public void Quit()
    {
        Debug.Log("Quitting");
        Resume();
        Application.Quit();
    }

    void SetUIActive(bool _active)
    {
        foreach (Transform child in transform)
            child.gameObject.SetActive(_active);
    }

    void FreeCursor()
    {
        if (Cursor.lockState != CursorLockMode.None)
        {
            previousMode = Cursor.lockState;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void RevertCursor()
    {
        Cursor.lockState = previousMode;
    }
}
