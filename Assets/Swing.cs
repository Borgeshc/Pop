using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    public Vector3 rotationPoint1;
    public Vector3 rotationPoint2;

    public float speed;

    RectTransform myRotation;

    private void Start()
    {
        myRotation = GetComponent<RectTransform>();
    }

    private void Update()
    {
        myRotation.localRotation = Quaternion.Lerp(Quaternion.Euler(rotationPoint1), Quaternion.Euler(rotationPoint2), (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    }
}
