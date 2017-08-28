using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] music;

    int currentSong;
    int lastSong;
    AudioSource source;

	void Start ()
    {
        DontDestroyOnLoad(gameObject);
        source = GetComponent<AudioSource>();

        source.clip = music[0];
        source.Play();
	}
	
	void Update ()
    {
		if(!source.isPlaying)
        {
            lastSong = currentSong;
            currentSong = Random.Range(0, music.Length);
            if (currentSong == lastSong)
                return;
            else
            {
                source.clip = music[currentSong];
                source.Play();
            }
        }
	}
}
