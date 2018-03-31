using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ApplyLevel : MonoBehaviour
{
	void Start ()
    {
        GetComponent<Text>().text = "Level " + SceneManager.GetActiveScene().buildIndex + " Complete! \n \n Time of Completion: ";
    }
}
