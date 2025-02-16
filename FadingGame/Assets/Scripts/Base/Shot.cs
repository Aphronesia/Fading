using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField]
    private float speed, countdown;
    private Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        StartCoroutine(SelfDestruction());
    }
    private void FixedUpdate(){
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    IEnumerator SelfDestruction(){
        yield return new WaitForSeconds(countdown);
        Destroy(gameObject);
    }
}
