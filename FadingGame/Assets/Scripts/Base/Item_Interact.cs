using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item_Interact : MonoBehaviour
{
    [SerializeField]
    private GameObject ButtonPress;
    [SerializeField]
    private UnityEvent action;
    
    private void Start() {
        ButtonPress = transform.Find("Button-to-press")?.gameObject;
        if (ButtonPress == null){
            Debug.Log("filho não achado");
        }
        else{
            ButtonPress.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")){
            ButtonPress.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")){
            ButtonPress.SetActive(false);
        }
    }
}
