using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void newGame()
    {
        SceneManager.LoadScene("SideScroll");
    }

    public void openLore()
    {
        SceneManager.LoadScene("Lore");
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void quitGame()
    {
        Application.Quit();
    }

}
