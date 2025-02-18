using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Nave_Move : MonoBehaviour
{
    [Header("Atriutos da Nave")]
    [SerializeField, Tooltip("velocidade da nave")]
    private float speed;

    private NaveInputActions naveControls;
    private InputAction move;

    private Rigidbody2D rig;
    Vector2 moveDirection = Vector2.zero;

    private void Awake() {
        naveControls = new NaveInputActions();
    }
    private void OnEnable() {
        move = naveControls.Nave.Move;
        move.Enable();
    }
    private void OnDesable(){
        move.Disable();
    }
    private void Start() {
        rig = GetComponent<Rigidbody2D>();
        
    }
    private void FixedUpdate(){
        Moviment();
    }
    private void Moviment(){
        moveDirection = move.ReadValue<Vector2>();
        rig.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }

}
