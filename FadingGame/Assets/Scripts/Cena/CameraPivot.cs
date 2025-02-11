using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivot : MonoBehaviour
{
    public Transform player ;
    private void FixedUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, player.position, 0.05f);
        if ( transform.position.y  > 7.8f ) {
            transform.position = new Vector3(transform.position.x,7.8f,0);
        }

        if ( transform.position.y  < -2.5f  ) {
            transform.position = new Vector3(transform.position.x,-2.5f,0);
        }

        if ( transform.position.x  > 28f) {
            transform.position = new Vector3(28f,transform.position.y,0);
        }
        if ( transform.position.x  < -28f  ) {
            transform.position = new Vector3(-28f,transform.position.y,0);
        }
    }
}
