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

    private Quaternion rotationZero, rotationN, RotationS;
    public float movedirectiony;

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
        Rotation();
        movedirectiony = moveDirection.y;
    }
    private void Moviment(){
        moveDirection = move.ReadValue<Vector2>();
        rig.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }
    private void Rotation(){
        rotationZero = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        rotationN = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 30);
        RotationS = Quaternion.Euler(0, transform.rotation.eulerAngles.y, -30);
        switch(moveDirection.y){
            case >0.1f:
                transform.rotation = Quaternion.Slerp(transform.rotation, rotationN, 10.0f * Time.deltaTime);
            break;
            case < -0.1f:
                transform.rotation = Quaternion.Slerp(transform.rotation, RotationS, 10.0f * Time.deltaTime);
            break;
            default:
                transform.rotation = Quaternion.Slerp(transform.rotation, rotationZero, 10.0f * Time.deltaTime);
            break;
        }
    }

}
