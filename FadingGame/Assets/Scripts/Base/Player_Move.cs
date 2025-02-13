using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    [SerializeField]
    private float speed, jumpForce;
    private bool isGrounded;
    private Rigidbody2D rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate(){
        Moviment();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded){
            Jump();
        }
    }
    private void Moviment(){
        float inputHorizontal = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(inputHorizontal * speed, rig.velocity.y);
    }
    private void Jump(){
        rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
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
