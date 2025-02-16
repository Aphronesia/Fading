using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivot : MonoBehaviour
{
    public Transform player;
    [SerializeField]
    private float speed, maxLimitX, minLimitX, maxLimitY, minLimitY;
    private void Start() {
        speed = speed * 0.01f;
    }
    private void FixedUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, player.position, speed);
        if (transform.position.y > maxLimitY)
        {
            transform.position = new Vector3(transform.position.x, 7.8f, 0);
        }

        if (transform.position.y < minLimitY)
        {
            transform.position = new Vector3(transform.position.x, -2.5f, 0);
        }

        if (transform.position.x > maxLimitX)
        {
            transform.position = new Vector3(28f, transform.position.y, 0);
        }
        if (transform.position.x < minLimitX)
        {
            transform.position = new Vector3(-28f, transform.position.y, 0);
        }
    }
}
