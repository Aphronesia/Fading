using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemCollectible : MonoBehaviour, IInteractable
{
    private GameObject buttonPress;
    private GameObject collectibleItem;
    [SerializeField, Tooltip("Método do player para executar quando interagir")]
    private UnityEvent<int> playerAction;
    [SerializeField, Tooltip("valor passado método")]
    private int actionValue;
    private bool collected = false;

    private void Start() {
        buttonPress = transform.Find("Button-to-press")?.gameObject;
        if (buttonPress == null){
            Debug.LogError($"botão não encontrado");
        } else{
            buttonPress.SetActive(false);
        }
        collectibleItem = transform.Find("Item-to-collect")?.gameObject;
        if (collectibleItem == null){
            Debug.LogError($"item coletavel não encontrado");
        } else{
            collectibleItem.SetActive(true);
        }
    }
    public void Interact(){
        if (collected == false){
            playerAction.Invoke(actionValue);
            buttonPress.SetActive(false);
            collectibleItem.SetActive(false);
            collected = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")){
            if (!collected){
                buttonPress.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")){
            buttonPress.SetActive(false);
        }
    }
}
