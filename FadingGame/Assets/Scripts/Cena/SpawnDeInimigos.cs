    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDeInimigos : MonoBehaviour
{

    [SerializeField]
    private GameObject _Trak_BlackPrefab;
    
    [SerializeField]
    private GameObject _Montro_verdePrefab;

    private float escalaRandom;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RotinaGeracaoInimigo());
        escalaRandom = Random.Range(0.5f, 2.0f);
        Vector3 escala = new Vector3 (escalaRandom, escalaRandom, escalaRandom);
        transform.localScale = escala;
    }

    IEnumerator RotinaGeracaoInimigo()
    {
        while ( 1==1 )
        {
            //spawn trak black
            Instantiate(_Trak_BlackPrefab, new Vector3(Random.Range(-44f,45f),20.17f,0),Quaternion.identity);
            yield return new WaitForSeconds(1);
            
            //spawn monstro verde
            Instantiate(_Montro_verdePrefab, new Vector3(50f,Random.Range(15f,-9f),0),Quaternion.identity);
            yield return new WaitForSeconds(3);
        }        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
