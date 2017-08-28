using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public static bool canMove;

    public LayerMask groundLayer;
    public float speed;
    public float jumpForce;
    public float checkGroundDistance;
    public AudioClip collectSound;

    bool lookingRight = true;

    float horizontal;
    float vertical;
    Rigidbody2D rb;
    CameraShake cameraShake;
    Animator anim;
    AudioSource source;


    private void Start()
    {
        canMove = false;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();

        if(Application.loadedLevel == 0)
        {
            canMove = true;
        }
    }

    private void Update()
    {
        if (Health.isDead)
            rb.velocity = Vector3.zero;

        if (!canMove) return;

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        rb.velocity = (new Vector2(horizontal * speed, vertical * speed));
        anim.SetFloat("Vertical", rb.velocity.y / 100);

        if ((horizontal > 0 && !lookingRight) || (horizontal < 0 && lookingRight))
            Flip();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag.Equals("Block"))
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("Break");
        }
    }

    public void Pop()
    {
        source.PlayOneShot(collectSound);
    }

    public void Flip()
    {
        lookingRight = !lookingRight;
        Vector3 myScale = transform.localScale;
        myScale.x *= -1;
        transform.localScale = myScale;
    }
}

