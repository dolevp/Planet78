using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour {


    public GameObject pauseMenu;
    public LevelManager lManager;
	// Use this for initialization
	void Start () {

        pauseMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeInHierarchy)
            {
                Resume();
            }
            else
            {
                OpenMenu();
            }
        }
	}

    public void GoMainMenu()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        lManager.BackToMenu();
    }
    public void GoToShop()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        lManager.GoShopping();
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void OpenMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
}
