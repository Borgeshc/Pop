using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    public Text quit;

    private void OnEnable()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0 && quit != null)
            quit.text = "Menu";
        else if (SceneManager.GetActiveScene().buildIndex == 0 && quit != null)
            quit.text = "Quit";
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadNextLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
            SceneManager.LoadScene(0);
        else
            Application.Quit();
    }
}
