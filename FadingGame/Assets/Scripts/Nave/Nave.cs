using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;
public class Nave : MonoBehaviour
{
    // variaveis da movmentacao
    public float velocidade, entradaHorizontal, entradaVertical;
    // caixa de selecao pra colocar o prefb do dardo
    public GameObject Dardo;
    //variaveis do dardo
    public float tempoDeDisparo, podeDisparar;
    //VIDA 
    public int navePorcentagem = 100;
    //primeiro frame
    void Start()
    {
        Debug.Log("Start de " + this.name);
    }
    //quando o jogo estiver acontecendo (todos os frames apos o primero)
    private void FixedUpdate()
    {
        //atribui a variavel o valor "1" se as teclas "Horizontal" forem pressionadas
        entradaHorizontal = Input.GetAxis("Horizontal");
        //atribui a variavel o valor "1" se as teclas "Vertical" forem pressionadas
        entradaVertical = Input.GetAxis("Vertical");
        //Cria um void pra essas duas variaveis
        Mover(entradaHorizontal, entradaVertical);
    }
    void Update()
    {
        //se botao esquerdo do mouse ("0") for apertado
        if (Input.GetMouseButtonDown(0))
        {
            //se Time.time for menor que pode disparar
            if (Time.time > podeDisparar)
            {
                //atribui ao Vector3 "mousePosicao" a posicao do mouse na tela
                Vector3 mousePosicao = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //atribui ao z do vector3 "mousePosicao" o valor de 0
                mousePosicao.z = 0f;
                //atribui ao vector3 "direcao" o valor de "mousePosicao" menos a posicao da nave
                Vector3 direcao = mousePosicao - transform.position;
                //matematica de rotacao que o dardo precisa estar para apontar na direcao do click do mouse 
                float anguloRad = Mathf.Atan2(direcao.y, direcao.x);
                float anguloDeg = Mathf.Rad2Deg * anguloRad;
                //atribui ao Quaternion "rotacaoDesejada" a rotacao, zera o valor de x e y e atribui apenas ao z
                Quaternion rotacaoDesejada = Quaternion.Euler(0f, 0f, anguloDeg);

                //Cria o objeto "Dardo" na mesma posicao da nave, e com a rotacao no valor da Quaternion "rotacaoDesejada"
                Instantiate(Dardo, transform.position + new Vector3(0, 0, 0), rotacaoDesejada);
                //atribui ao valor "podeDisparar" Time.time + tempodeDisparo
                podeDisparar = Time.time + tempoDeDisparo;
            }
        }
        Rotacao();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ataque")
        {
            Destroy(other.gameObject);
            DanoSimples();
        }
    }

    //Void Mover criado em Void FixedUpdate
    void Mover(float entradaHorizontal, float entradaVertical)
    {
        //cria o vector3 "movimento", atribui a x "entradaHorizontal", a y "entradaVertical", a z 0
        Vector3 movimento = new Vector3(entradaHorizontal, entradaVertical, 0f);
        //normaliza os valores de movimento
        movimento.Normalize();
        //cria o vector3 "novaPosicao, atrivui a ele a posicao da nave, mais movimento multiplicado pela velocidade e pelo tempo
        Vector3 novaPosicao = transform.position + movimento * velocidade * Time.deltaTime;
        //No componente Rigidbody2D, usa o metodo MovePosition e da a ele o valor de "novaPosicao"
        GetComponent<Rigidbody2D>().MovePosition(novaPosicao);
    }
    void Rotacao()
    {
        Quaternion rotacaoWS0 = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        Quaternion rotacaoW = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 30);
        if (Input.GetKey(KeyCode.W)){ 
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoW, 10.0f * Time.deltaTime); 
        }
        else{ 
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoWS0, 10.0f * Time.deltaTime); 
        }
        Quaternion rotacaoS = Quaternion.Euler(0, transform.rotation.eulerAngles.y, -30);
        if (Input.GetKey(KeyCode.S)){ 
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoS, 10.0f * Time.deltaTime); 
        }
    }
    public void DanoSimples()
    {
        //vidas = vidas - 1;
        navePorcentagem = navePorcentagem - 5;

        if (navePorcentagem < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
