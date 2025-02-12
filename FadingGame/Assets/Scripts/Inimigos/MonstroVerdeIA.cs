using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstroVerdeIA : MonoBehaviour
{
    // variavel da velocidade
    public float veloc = 30.0f;
    //variavel do alvo
    public Transform alvo ;
    //variavel pra se deve seguir ou não
    public bool colidindoNave = false;
    //cria o corpo rigido (Rigidbody2D) "rb2d"
    private Rigidbody2D rb2d;

    private float escalaRandom;
    //quando iniciar o jogo (primeiro frame)
    void Start()
    {
        // atribui ao corpo rigido o componente "Rigidbody2D"
        rb2d =GetComponent<Rigidbody2D>();
        //atribui ao objeto "nave" todos os objetos com Tag "Nave"
        GameObject nave = GameObject.FindWithTag("Nave");
        // se "nave" for diferente de null(nulo)
        if (nave != null){
            //atribui a variavel "alvo" o transform da variavel "nave"
            alvo = nave.transform;
        }
        //atribui ao Objeto "bordas" todos os objetos encontrados com a Tag "Borda"
        GameObject[] bordas = GameObject.FindGameObjectsWithTag("Borda");
        //executa pra cada objeto "bordas" 
        foreach (GameObject borda in bordas)
        {
            //se colisão com objeto "borda" for diferente de nula (null)
            if (borda.GetComponent<BoxCollider2D>() != null)
            {
                //classe Physics2D torna "IgnoreCollision"(ignorar colisão) verdadeira(true) entre o "Collider2D" do monstro com o "BoxCollider2D" da borda
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), borda.GetComponent<BoxCollider2D>(), true);
            }
        }
        escalaRandom = Random.Range(0.2f, 0.4f);
        Vector3 escala = new Vector3 (escalaRandom, escalaRandom, escalaRandom);
        transform.localScale = escala;
    }
    //durante o jogo (após primeiro frame)
    private void FixedUpdate() {
        //separa o codigo de seguir
        Seguir();
    }
     // quando acontecer colisão
    void OnTriggerEnter2D(Collider2D other)
    {
        //falar no console
        Debug.Log("O objeto " + name + " colidiu com o objeto " + other.name);
        
        //se a colisão for da tag "Nave
        if ( other.tag == "Nave"){
            //atribui a variavel "colidindoNave" como verdadeira
            colidindoNave = true;
        }
    }
    //se a colisão for encerrada
    void OnTriggerExit2D(Collider2D other)
    {
        // se a colisão encerrada for com objeto da tag "Nave"
        if ( other.tag == "Nave"){
            colidindoNave = false;
        }
    }
    //void Seguir (criado dentro de Update)
    private void Seguir()
    {
        //se alvo for diferente de nulo
        if (alvo != null){
            //cria variavel Vector3 "direção", atribui a ela a posição do alvo menos a do monstro
            Vector3 direcao = alvo.position - transform.position;
            //normaliza a direção
            direcao.Normalize();
            //cria Vectoe2 "movimento"
            Vector2 movimento = new Vector2 (direcao.x, direcao.y) * veloc * Time.deltaTime;
            //
            //na classe do corpo rigido, usa o metodo "MovePosition" pra adicionar a posição do corpo o movimendo
            rb2d.MovePosition(rb2d.position + movimento);
        }
    }
}
