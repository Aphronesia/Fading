using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canhao : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane));

        // Passo 2: Calcular a rotação
        Vector3 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Passo 3: Aplicar a rotação ao objeto
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
