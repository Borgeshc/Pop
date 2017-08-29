using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject world;
    public GameObject[] blocks;
    public Text gameTimer;

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

    bool startGameTime;
    bool ended;

    private void Start()
    {
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
        StartCoroutine(StartCountdown(5));

    }

    IEnumerator StartCountdown(int length)
    {
        for(int i = length; i > 0; i--)
        {
            startTimer.text = "Starting in " + i + "...";
            yield return new WaitForSeconds(1);
        }
        StartScreen.SetActive(false);
        startGameTime = true;
        world.SetActive(true);
        Movement.canMove = true;
    }

    private void Update()
    {
        if(startGameTime)
        {
            gameTime = (int)Time.time;
            gameTimer.text =  gameTime.ToString();
        }

        if(blockCount <= 0 && !ended)
        {
            ended = true;
            Movement.canMove = false;
            gameTimer.gameObject.SetActive(false);
            endScreen.SetActive(true);
            finalTime.text = gameTime.ToString() + " Seconds!";
            nextLevelButton.SetActive(true);
            Health.cantDied = true;
        }
    }

    public void BlockDestroyed()
    {
        blockCount--;
    }

}
