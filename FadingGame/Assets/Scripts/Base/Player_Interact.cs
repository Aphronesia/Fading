using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Interact : MonoBehaviour
{
    private string otherTag;
    private PlayerInputActions playerControls;
    private InputAction interact;

    private void Awake() {
        playerControls = new PlayerInputActions();
    }
    private void OnEnable() {
        interact = playerControls.Player.Interact;
        interact.Enable();
        interact.performed += Interact;
    }
    private void OnDisable() {
        interact.Disable();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        otherTag = other.gameObject.tag;
    }
    private void OnTriggerExit2D(Collider2D other) {
        otherTag = null;
    }
    private void Interact(InputAction.CallbackContext context){
        switch (otherTag)
        {
            
            default:
                break;
        }
    }

}
