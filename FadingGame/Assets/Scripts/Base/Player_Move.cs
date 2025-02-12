using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    private int speed;
    private void FixedUpdate(){
        Moviment();
    }
    private void Moviment(){
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");
        Vector3 moviment = new Vector3 (inputHorizontal, inputVertical, 0f);
        moviment.Normalize();
    }
}
