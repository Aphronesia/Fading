using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Shot : MonoBehaviour
{
    [SerializeField]
    private GameObject shot;
    [SerializeField]
    private float canShoot, countdown;

    private PlayerInputActions playerControls;
    private InputAction fire;

    private void Awake() {
        playerControls = new PlayerInputActions();
    }
    private void OnEnable() {
        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;
    }
    private void OnDesable(){
        fire.Disable();
    }
    private void Fire(InputAction.CallbackContext context){
        if (Time.time > canShoot){
            Instantiate(shot, transform.position + new Vector3(0, 0, 0), transform.rotation);
            canShoot = Time.time + countdown;
        }
    }
}
