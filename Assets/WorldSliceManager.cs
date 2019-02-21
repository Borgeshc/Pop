using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSliceManager : MonoBehaviour
{
    public static WorldSliceManager Instance;
    public ObjectPooling worldSlicePool;
    public int offsetBy;

    Movement player;
    int currentOffset = 38;
    List<GameObject> slicesInUse = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Movement>();
        foreach (GameObject slice in worldSlicePool.objectsInUse)
            slicesInUse.Add(slice);
    }

    public void NextSlice()
    {
        print("Next Slice");
        currentOffset += offsetBy;

        slicesInUse[0].SetActive(false);
        slicesInUse.RemoveAt(0);

        GameObject slice = worldSlicePool.GetPooledObject();
        if (!slice) return;
        slicesInUse.Add(slice);
        slice.transform.position = new Vector3(currentOffset, 0, 0);
        slice.SetActive(true);
    }
}
