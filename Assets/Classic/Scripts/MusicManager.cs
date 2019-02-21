using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] music;

    int currentSong;
    int lastSong;
    AudioSource source;
    float oldVolume;
    bool mute;

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

    public void UpdateVolume(Slider slider)
    {
        source.volume = slider.value;
    }

    public void Mute()
    {
        mute = !mute;

        if(mute)
        {
            oldVolume = source.volume;
            source.volume = 0;
        }
        else
            source.volume = oldVolume;
    }
}
