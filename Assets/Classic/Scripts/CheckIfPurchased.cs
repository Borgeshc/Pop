using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckIfPurchased : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.GetInt("AdsRemoved") == 1)
        {
            IAPManager.adsRemoved = true;
            gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("AdsRemoved") == 1)
        {
            IAPManager.adsRemoved = true;
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("AdsRemoved") == 1)
        {
            IAPManager.adsRemoved = true;
            gameObject.SetActive(false);
        }
    }
}
