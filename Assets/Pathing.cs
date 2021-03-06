﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathing : MonoBehaviour
{
    public float speed;

    public Vector3 point1;
    public Vector3 point2;

    RectTransform myPosition;

    private void Start()
    {
        myPosition = GetComponent<RectTransform>();
    }

    private void Update()
    {
        myPosition.localPosition = Vector3.Lerp(point1, point2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    }
}
