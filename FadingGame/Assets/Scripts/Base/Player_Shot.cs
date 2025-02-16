using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Shot : MonoBehaviour
{
    [Header("Atributos do disparo")]
    [SerializeField, Tooltip("Objeto a ser instanciado")]
    private GameObject shot;
    [SerializeField, Tooltip("Boleana que permiti o disparo")]
    private float canShoot;
    [SerializeField, Tooltip("tempo entre um disparo ao outro")]
     private float countdown;

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
