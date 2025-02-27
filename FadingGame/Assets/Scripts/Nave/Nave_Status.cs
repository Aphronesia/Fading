using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave_Status : MonoBehaviour
{
    [Header("Atributos da Nave")]
    [SerializeField, Tooltip("vida em porcentagem da nave")]
    private int NaveIntegrity;
    private bool collEnemy = false;
    private void OnTriggerEnter2D(Collider2D other) {
        switch (other.tag){
            case "Ataque":
                Destroy(other.gameObject);
                Damage(5);
            break;
            case "Enemy":
                collEnemy = true;
                StartCoroutine(ColliderDamage());
            break;
            default:
            break;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        switch (other.tag){
            case "Enemy":
                collEnemy = false;
                Debug.Log("nao é pra da dano mais ferle");
                StartCoroutine(ColliderDamage());
            break;
            default:
            break;
        }
    }
    IEnumerator ColliderDamage(){
        while(collEnemy == true){
            Debug.Log(collEnemy);
            Damage(15);
            yield return new WaitForSeconds(1);
        }
    }
    private void Damage(int value){
        NaveIntegrity = NaveIntegrity - value;
        if (NaveIntegrity < 1){
            Destroy(this.gameObject);
        }
    }
}
