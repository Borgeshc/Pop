using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckIfPurchased : MonoBehaviour
{
    private void Awake()
    {
        if (IAPManager.adsRemoved)
            gameObject.SetActive(false);
    }

    private void Start()
    {
        if (IAPManager.adsRemoved)
            gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if (IAPManager.adsRemoved)
            gameObject.SetActive(false);
    }
}
