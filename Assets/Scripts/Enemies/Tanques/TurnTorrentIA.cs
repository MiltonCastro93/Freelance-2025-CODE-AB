using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTorrentIA : MonoBehaviour
{
    [SerializeField] private float tiempoTurn = 1f;
    [SerializeField] private GameObject targetEnemy;
    [SerializeField] private EnemyTank _baseEnemy;
    private BulleType BulleType;
    private Rigidbody _rb;
    public float angleMin = 2f;


    // Start is called before the first frame update
    void Start() {
        _rb = GetComponent<Rigidbody>();
        _baseEnemy = GetComponentInParent<EnemyTank>();
        BulleType = GetComponentInChildren<BulleType>();
    }


    private void Update() {
        _baseEnemy.stopForFire = targetEnemy != null ? true : false;
    }


    private void FixedUpdate() {
        if (targetEnemy != null) {
            Vector3 direction = (targetEnemy.transform.position - transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            Quaternion smoothRotation = Quaternion.Slerp(transform.rotation, targetRotation, tiempoTurn * Time.deltaTime);
            _rb.MoveRotation(smoothRotation);
            BulleType.BulletON(angleMin <= Quaternion.Angle(smoothRotation, targetRotation));
        } else {
            transform.rotation = transform.parent.rotation;
        }

        
    }



    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            targetEnemy = other.gameObject;
        }

    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            targetEnemy = null;
        }
    }


}
