using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void options()
    {
        SceneManager.LoadScene("Setting");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
