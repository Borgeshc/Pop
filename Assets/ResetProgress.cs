using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetProgress : MonoBehaviour
{
    public GameObject[] levels;
    
	public void Reset ()
    {
		for(int i = 0; i < levels.Length; i++)
        {
            PlayerPrefs.SetInt(levels[i].name, 0);
            PlayerPrefs.SetInt(levels[i].name + "Unlocked", 0);

            print("All progress has been reset.");
        }
	}
}
