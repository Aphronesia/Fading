using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public class Disparo : MonoBehaviour
{
    //variaveis
     public float velocdisparo = 12.0f ;
     public float time = 0.0f;
    void Start()
    {
        

    }
    //durante o jogo (após primeiro frame)
    void Update()
    {
        // pra fazer ele sumir dps (aqui uma base pra vc ferle)
        time += Time.deltaTime;
        if ( time > 1.0f){Destroy(this.gameObject);}
        if ( transform.position.x  > 46.5f) {
            Destroy(this.gameObject);
        }
    }
    private void FixedUpdate() {
        transform.Translate(Vector3.right * velocdisparo * Time.deltaTime);
    }
    // quando acontecer colisão
    private void OnTriggerEnter2D(Collider2D other)
    {
        //falar no console
        Debug.Log("O objeto " + name + " colidiu com o objeto " + other.name);

        //se a colisão for da tag dardo 
        if ( other.tag == "Inimigo")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }

        
    }
    
}
