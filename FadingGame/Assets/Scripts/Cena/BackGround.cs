using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    // Definição das variaveis
    // teste github
    public float velocidade = 10.0f;
    public float reposicao = 18f;
    public Vector3 posicaoInicial;
    // Start is called before the first frame update
    void Start()
    {
       posicaoInicial = transform.position;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        float novaPosicao = Mathf.Repeat(Time.time * velocidade , reposicao );
        transform.position = posicaoInicial + Vector3.left * novaPosicao ;
    }
}
