using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrekRange : MonoBehaviour
{
    public GameObject Red_Ball;

    public float podeAtacar = 0.0f;
    public float tempodeAtaque = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Nave"){
            if (Time.time > podeAtacar){
                Instantiate(Red_Ball,transform.position + new Vector3(0,5.0f,0), Quaternion.identity);
                podeAtacar = Time.time + tempodeAtaque;
            }
        }
    }
}
