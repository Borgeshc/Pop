﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject world;
    public GameObject[] blocks;
    public Text gameTimer;

    public int oneStartTime;
    public int twoStarTime;
    public int threeStarTime;

    [Space]
    public GameObject StartScreen;
    public GameObject startText;
    public Text startTimer;
    [Space]
    public GameObject endScreen;
    public Text finalTime;
    public GameObject nextLevelButton;

    int startingBlockCount;
    int blockCount;
    int timeCompleted;
    int gameTime;
    int timeBeforeTimer;

    bool startGameTime;
    bool ended;

    private void Start()
    {
        gameTime = 0;
        ended = false;
        Health.cantDied = false;
        startingBlockCount = blocks.Length;
        blockCount = startingBlockCount;
        StartCoroutine(StartingScreen());
    }

    IEnumerator StartingScreen()
    {
        StartScreen.SetActive(true);
        yield return new WaitForSeconds(3);
        startText.SetActive(false);

        startTimer.gameObject.SetActive(true);
        StartCoroutine(StartCountdown(3));

    }

    IEnumerator StartCountdown(int length)
    {
        for(int i = length; i > 0; i--)
        {
            startTimer.text = "Starting in " + i + "...";
            yield return new WaitForSeconds(1);
        }
        StartScreen.SetActive(false);
        timeBeforeTimer = (int)Time.timeSinceLevelLoad;
        startGameTime = true;
        world.SetActive(true);
        Movement.canMove = true;
        gameTimer.gameObject.SetActive(true);
    }

    private void Update()
    {
        if(startGameTime)
        {
            gameTime = (int)Time.timeSinceLevelLoad - timeBeforeTimer;
            gameTimer.text =  gameTime.ToString();
        }

        if(blockCount <= 0 && !ended)
        {
            ended = true;
            GameEnded();
        }
    }

    void GameEnded()
    {

        Movement.canMove = false;
        gameTimer.gameObject.SetActive(false);
        endScreen.SetActive(true);
        timeCompleted = gameTime;
        finalTime.text = gameTime.ToString() + " Seconds!";
        nextLevelButton.SetActive(true);
        Health.cantDied = true;
        CheckStars();
    }

    void CheckStars()
    {
        if(timeCompleted <= oneStartTime)
        {
            if (PlayerPrefs.GetInt(Application.loadedLevelName) < 1)
                PlayerPrefs.SetInt(Application.loadedLevelName, 1);
            if(timeCompleted <= twoStarTime)
            {
                if (PlayerPrefs.GetInt(Application.loadedLevelName) < 2)
                    PlayerPrefs.SetInt(Application.loadedLevelName, 2);

                if(timeCompleted <= threeStarTime)
                {
                    if (PlayerPrefs.GetInt(Application.loadedLevelName) < 3)
                        PlayerPrefs.SetInt(Application.loadedLevelName, 3);
                }
            }
        }
        else
            PlayerPrefs.SetInt(Application.loadedLevelName, 4);
    }

    public void BlockDestroyed()
    {
        blockCount--;
    }

}
