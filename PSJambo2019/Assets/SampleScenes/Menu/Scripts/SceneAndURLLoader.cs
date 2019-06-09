using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using ShitMenu;

public class SceneAndURLLoader : MonoBehaviour
{
    private ShitMenu.StandardPauseMenu m_PauseMenu;


    private void Awake ()
    {
        m_PauseMenu = GetComponentInChildren <ShitMenu.StandardPauseMenu> ();
    }


    public void SceneLoad(string sceneName)
	{
		//PauseMenu pauseMenu = (PauseMenu)FindObjectOfType(typeof(PauseMenu));
		m_PauseMenu.MenuOff ();
		SceneManager.LoadScene(sceneName);
	}


	public void LoadURL(string url)
	{
		Application.OpenURL(url);
	}
}

