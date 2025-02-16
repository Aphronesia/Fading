using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Move : MonoBehaviour
{
    [SerializeField]
    private float speed, jumpForce;
    private bool isGrounded;
    private Rigidbody2D rig;
    private Animator anim;
    
    private PlayerInputActions playerControls;
    private InputAction move;
    private InputAction jump;

    Vector2 moveDirection = Vector2.zero;
    private void Awake() {
        playerControls = new PlayerInputActions();
    }
    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        jump = playerControls.Player.Jump;
        jump.Enable();
        jump.performed += Jump;
    }
    private void OnDesable()
    {
        move.Disable();
        jump.Disable();
    }
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("Walk", false);
    }
    private void FixedUpdate(){
        Moviment();
        Rotation();
    }
    private void Moviment(){
        moveDirection = move.ReadValue<Vector2>();
        rig.velocity = new Vector2(moveDirection.x * speed, rig.velocity.y);
    }
    private void Rotation(){
        Vector2 diretion = move.ReadValue<Vector2>();
        if (diretion.x > 0.1f){
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            anim.SetBool("Walk", true);
        } else if (diretion.x < -0.1f)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            anim.SetBool("Walk", true);
        }
        else{
            anim.SetBool("Walk", false);
        }
    }
    private void Jump(InputAction.CallbackContext context){
        if (isGrounded){
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")){
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")){
            isGrounded = false;
        }
    }
}
