using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave_Status : MonoBehaviour
{
    [Header("Atributos da Nave")]
    [SerializeField, Tooltip("vida em porcentagem da nave")]
    private int NaveIntegrity;
    private void OnTriggerEnter2D(Collider2D other) {
        switch (other.tag){
            case "Ataque":
                Destroy(other.gameObject);
                Damage(5);
            break;
            default:
            break;
        }
    }
    private void Damage(int value){
        NaveIntegrity = NaveIntegrity - value;
        if (NaveIntegrity < 1){
            Destroy(this.gameObject);
        }
    }
}
