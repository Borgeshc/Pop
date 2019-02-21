using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollCamera : MonoBehaviour
{
    Transform player;
    Vector3 velocity;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    private void LateUpdate()
    {
        if (Camera.main.WorldToScreenPoint(player.transform.position).x >= Screen.width / 2)
        {
            Vector3 newPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, 0);
        }
    }
}
