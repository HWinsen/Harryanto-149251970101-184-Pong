using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenAuthor()
    {
        Debug.Log("Created by Harryanto - 149251970101-184");
    }

    public void OpenCredit()
    {
        SceneManager.LoadScene("Credit");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
