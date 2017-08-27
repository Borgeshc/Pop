using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float force;
    public bool bounceLeft;
    public bool bounceRight;
    public bool bounceDown;
    Rigidbody2D player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.rigidbody.Equals(player))
        {
            print(collision.gameObject.name);
            if(bounceLeft)
                player.AddForce(Vector3.left * force, ForceMode2D.Impulse);
            else if (bounceRight)
                player.AddForce(Vector3.right * force, ForceMode2D.Impulse);
            else if (bounceDown)
                player.AddForce(Vector3.down * force, ForceMode2D.Impulse);
        }
    }
}
