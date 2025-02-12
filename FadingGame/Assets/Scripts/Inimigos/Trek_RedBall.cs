using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trek_RedBall : MonoBehaviour
{
    public float veloc = 10.0f;
    private Rigidbody2D rb2d;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.y  < -16f){
        Destroy(this.gameObject);
        }
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
    private void FixedUpdate() {
        rb2d.velocity = new Vector2(0, -veloc);
    }
}
