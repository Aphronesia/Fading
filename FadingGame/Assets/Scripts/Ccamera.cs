using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Ccamera : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject _target;

    [SerializeField]
    private Vector2 targetOffset ;
    void Start()
    {
        targetOffset.x = 3;
        targetOffset.y = 4;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mouseScreenPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        mouseScreenPosition.x = (mouseScreenPosition.x - 0.5f) * 2f;
        mouseScreenPosition.y = (mouseScreenPosition.y - 0.5f) * 2f;

        mouseScreenPosition.x = Mathf.Clamp(mouseScreenPosition.x, -1f, 1f);
        mouseScreenPosition.y = Mathf.Clamp(mouseScreenPosition.y, -1f, 1f);

        

        float offsetX = targetOffset.x * mouseScreenPosition.x;
        float offsetY = targetOffset.y * mouseScreenPosition.y;

        Vector3 CameraPosition = new Vector3(_target.transform.position.x + offsetX, _target.transform.position.y +offsetY, transform.position.z );

        transform.position = CameraPosition;
    }
}