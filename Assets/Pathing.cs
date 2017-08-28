using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathing : MonoBehaviour
{
    public float speed;

    public Vector3 point1;
    public Vector3 point2;

    RectTransform myPosition;
    bool moveTo1;
    float lerpSpeed;

    private void Start()
    {
        myPosition = GetComponent<RectTransform>();
        moveTo1 = true;
    }

    private void Update()
    {
        if (moveTo1)
            myPosition.localPosition = Vector2.Lerp(myPosition.localPosition, point1, speed * Time.deltaTime);
        else
            myPosition.localPosition = Vector2.Lerp(myPosition.localPosition, point2, speed * Time.deltaTime);

        if (Vector3.Distance(myPosition.localPosition, point1) < 1)
            moveTo1 = false;
        if (Vector3.Distance(myPosition.localPosition, point2) < 1)
            moveTo1 = true;
    }
}
