using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Interact : MonoBehaviour
{
    [Header("Configurações de Interação")]
    [Tooltip("Raio em que o objeto interagível pode ser detectado")]
    public float interactionRadius;
    [Tooltip("Layer dos objetos interagiveis")]
    public LayerMask interactableLayer;
    private PlayerInputActions playerControls;
    private InputAction interact;
    private Player_Shot player_Shot;

    private void Awake(){
        playerControls = new PlayerInputActions();
    }
    private void OnEnable(){
        interact = playerControls.Player.Interact;
        interact.Enable();
        interact.performed += OnInteract;
    }
    private void OnDisable(){
        interact.Disable();
    }
    private void Start(){
        player_Shot = GetComponent<Player_Shot>();
    }
    private void OnInteract(InputAction.CallbackContext context){
        if (context.performed){
            CheckAndInteract();
        }
    }
    private void CheckAndInteract(){
        Collider2D collider = Physics2D.OverlapCircle(transform.position, interactionRadius, interactableLayer); //detecta objeto com collider na layer Interactable
        if (collider != null){
            IInteractable interactable = collider.GetComponent<IInteractable>();
            if (interactable != null){
                interactable.Interact();
            }
        }
    }
    public void Interactions(int actionValue){
        switch (actionValue)
        {
            case 0:
                if (player_Shot != null){
                    player_Shot.enabled = true;
                }
                break;
            default:
                break;
        }
    }
    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
