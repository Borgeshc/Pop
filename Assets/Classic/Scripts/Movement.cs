using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public static bool canMove;
    public float speed;
    public AudioClip collectSound;

    [HideInInspector]
    public bool lookingRight = true;

    float horizontal;
    float vertical;
    Rigidbody2D rb;
    Animator anim;
    AudioSource source;
    RectTransform myTransform;
    GameManager gameManager;

    Vector2 velocity;

    private void Start()
    {
        canMove = false;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        // myTransform = GetComponent<RectTransform>();

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            canMove = true;
        }
        //else
        // gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void FixedUpdate()
    {
        // if(gameManager != null)
        //if (Health.isDead || gameManager.ended)
        //{
        //    rb.velocity = Vector3.zero;
        //    anim.SetFloat("Vertical", 0);
        //}

        //if (!canMove) return;

        if (Application.isMobilePlatform)
        {
            MobileMove();
        }
        else
        {
            PCMove();
        }

        ClampObjectIntoView();
    }

    void PCMove()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);
        move *= speed * Time.deltaTime;
        rb.velocity = move;
        anim.SetFloat("Vertical", rb.velocity.y / 100);

        if ((horizontal > 0 && !lookingRight) || (horizontal < 0 && lookingRight))
            Flip();
    }

    void MobileMove()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                Vector3 pos = touch.position;
                pos.z = transform.position.z - Camera.main.transform.position.z;
                pos = Camera.main.ScreenToWorldPoint(pos);
                transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);

                rb.velocity = Vector3.zero;

                velocity = (pos - transform.position).normalized;
                anim.SetFloat("Vertical", velocity.y);

                if ((velocity.x > 0 && !lookingRight) || (velocity.x < 0 && lookingRight))
                    Flip();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag.Equals("Block"))
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

    // Clamp object into view, requires a transform and an offset
    void ClampObjectIntoView()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, 0.05f, 0.95f);
        pos.y = Mathf.Clamp(pos.y, 0.1f, 0.9f);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}

