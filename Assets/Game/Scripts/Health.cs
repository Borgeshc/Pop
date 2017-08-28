using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public static bool isDead;
    public Text reviveTime;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public IEnumerator Died()
    {
        isDead = true;
        Movement.canMove = false;
        anim.SetBool("Died", true);

        yield return new WaitForSeconds(1.5f);
        transform.position = Vector3.zero;
        reviveTime.gameObject.SetActive(true);

        for(int i = 3; i > 0; i--)
        {
            reviveTime.text = "Respawning in " + i + "...";
            yield return new WaitForSeconds(1);

            if(i == 2)
                anim.SetBool("Died", false);
        }

        reviveTime.gameObject.SetActive(false);
        Movement.canMove = true;
        isDead = false;
    }
}
