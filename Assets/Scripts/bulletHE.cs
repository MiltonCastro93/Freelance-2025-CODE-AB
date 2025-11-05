using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHE : MonoBehaviour,IChangety {
    [SerializeField] float _speed = 2;
    [SerializeField] float _damage = 25;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision) {
        IDamage damage = collision.collider.GetComponentInParent<IDamage>();
        if (damage != null) {
            damage.Getdamage(_damage);
        }

        Destroy(gameObject);
    }

    private void FixedUpdate() {
        rb.AddForce(transform.forward * _speed * Time.deltaTime);
    }

    public void swichbullet() {
        //no use el addforce aca me salta error
    }

}
