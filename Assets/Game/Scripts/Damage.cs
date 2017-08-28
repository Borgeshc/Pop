using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    Health playerHealth;

    private void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("Player") && !Health.isDead)
        {
            StartCoroutine(playerHealth.Died());
        }
    }
}
