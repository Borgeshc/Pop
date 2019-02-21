using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public GameObject[] levels;
    int currentPage;
    int previousPage;

    private void Start()
    {

    }

    public void NextPage()
    {
        levels[currentPage].SetActive(false);

        if (currentPage + 1 > levels.Length - 1)
            currentPage = 0;
        else
            currentPage++;

        levels[currentPage].SetActive(true);
    }

    public void PreviousPage()
    {
        levels[currentPage].SetActive(false);

        if (currentPage - 1 < 0)
            currentPage = levels.Length - 1;
        else
            currentPage--;

        levels[currentPage].SetActive(true);
    }
}
