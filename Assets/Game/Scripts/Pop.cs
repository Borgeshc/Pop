using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pop : MonoBehaviour
{
    GameManager gameManager;
    Movement player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Movement>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void Popping()
    {
        player.Pop();
    }

    public void Disable()
    {
        gameManager.BlockDestroyed();
        gameObject.SetActive(false);
    }
}
