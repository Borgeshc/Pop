using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMusicManager : MonoBehaviour
{
    public GameObject musicManagerPrefab;

    void Start()
    {
        if (GameObject.Find("MusicManager") == null)
        {
            GameObject musicManager = Instantiate(musicManagerPrefab) as GameObject;
            musicManager.name = "MusicManager";
        }
    }
}
