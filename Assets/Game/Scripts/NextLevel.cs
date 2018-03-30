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
        if (Application.loadedLevel != 0 && quit != null)
            quit.text = "Menu";
        else if (Application.loadedLevel == 0 && quit != null)
            quit.text = "Quit";
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(Application.loadedLevel + 1);
    }

    public void Quit()
    {
        if (Application.loadedLevel != 0)
            SceneManager.LoadScene(0);
        else
            Application.Quit();
    }
}
