using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrekAi : MonoBehaviour
{

    public float veloc = 5.0f;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
    }
    
    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(0, -veloc);
        if (transform.position.y  < -16f){
        Destroy(this.gameObject);
        }
        //atribui ao Objeto "bordas" todos os objetos encontrados com a Tag "Borda"
        GameObject[] bordas = GameObject.FindGameObjectsWithTag("Borda");
        foreach (GameObject borda in bordas)
        {
            //se colisão com objeto "borda" for diferente de nula (null)
            if (borda.GetComponent<BoxCollider2D>() != null)
            {
                //classe Physics2D torna "IgnoreCollision"(ignorar colisão) verdadeira(true) entre o "Collider2D" do monstro com o "BoxCollider2D" da borda
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), borda.GetComponent<BoxCollider2D>(), true);
            }
        }
    }
    


}
