using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckScene : MonoBehaviour
{
    public GameObject itemToDisableInMenu;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        print("Scene " + scene.buildIndex + " Loaded" );
        if(scene.buildIndex == 0)
        {
            itemToDisableInMenu.SetActive(false);
        }
        else
        {
            itemToDisableInMenu.SetActive(true);
        }
    }
}
