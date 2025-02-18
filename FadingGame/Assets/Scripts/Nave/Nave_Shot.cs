using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Nave_Shot : MonoBehaviour
{
    [Header("Atribudos do disparo")]
    [SerializeField, Tooltip("Objeto a ser instanciado")]
    private GameObject shot;
    [SerializeField, Tooltip("tempo entre um disparo ao outro")]
    private float countdown;
    private Vector3 mousePositionVec = Vector3.zero;
    private Vector3 direction = Vector3.zero;
    private float angleRad, angleDeg, canShoot;
    private Quaternion rotationDesired;

    private NaveInputActions naveControls;
    private InputAction fire;
    private void Awake() {
        naveControls = new NaveInputActions();
    }
    private void OnEnable() {
        fire = naveControls.Nave.Fire;
        fire.Enable();
        fire.performed += Fire;
    }
    private void Fire (InputAction.CallbackContext context){
        if (Time.time > canShoot){
            mousePositionVec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePositionVec.z = 0f;
            direction = mousePositionVec - transform.position;
            angleRad = Mathf.Atan2(direction.y, direction.x);
            angleDeg = Mathf.Rad2Deg * angleRad;
            rotationDesired = Quaternion.Euler(0f, 0f, angleDeg);
            Instantiate(shot, transform.position + new Vector3(0,0,0), rotationDesired);
            canShoot = Time.time + countdown;
        }
    }


}
