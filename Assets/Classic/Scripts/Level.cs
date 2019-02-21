using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public GameObject locked;
    public GameObject unlocked;

    public Image star1;
    public Image star2;
    public Image star3;

    public Sprite starGainedImage;

    private void Start()
    {
        locked = transform.Find("Locked").gameObject;
        unlocked = transform.Find("Unlocked").gameObject;

        star1 = transform.Find("Star1").GetComponent<Image>();
        star2 = transform.Find("Star2").GetComponent<Image>();
        star3 = transform.Find("Star3").GetComponent<Image>();

        if (PlayerPrefs.GetInt(transform.name + "Unlocked") > 0)
        {
            unlocked.SetActive(true);
        }
        else
        {
            if(transform.name != "Level1")
                locked.SetActive(true);
        }

        UpdateStars();
    }

    void UpdateStars()
    {
        switch(PlayerPrefs.GetInt(transform.name))
        {
            case 1:
                star1.sprite = starGainedImage;
                break;
            case 2:
                star1.sprite = starGainedImage;
                star2.sprite = starGainedImage;
                break;
            case 3:
                star1.sprite = starGainedImage;
                star2.sprite = starGainedImage;
                star3.sprite = starGainedImage;
                break;
            case 4:
                break;
        }
    }
}
