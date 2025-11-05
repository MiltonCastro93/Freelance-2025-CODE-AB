using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTank : factory, IDamage, IGetLife, IHealding
{
    private Rigidbody rb;
    [SerializeField] float distanceTo = 12f;
    private Vector3 newPosition = Vector3.zero;
    public float currentDistance;
    public bool stopForFire = false;
    private AudioSource _aS;

    void Start() {
        rb = GetComponent<Rigidbody>();

        newPosition = transform.position;
        turnspeed = 120f;
        speed = 3f;
        _aS = GetComponent<AudioSource>();
    }

    private void Update() {
        health = Mathf.Clamp(health, 0f, 100f);
    }

    private void FixedUpdate() {
        if (health >= 1) {
            if (stopForFire) {
                fire();
            } else {
                movement();
            }
        } else {
            GameManager.Instancia.conditionWinner(1);
            Destroy(gameObject);//volverlo a la pool
        }


    }

    public virtual void Getdamage(float damage) {
        health -= damage;
    }

    protected override void fire() {
        //Tirar chaf?
    }

    protected override void movement() {
        _aS.pitch = Mathf.Clamp(Random.Range(-1f, 1f), -1, 1);
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.forward,out hit)) {
            currentDistance = hit.distance > distanceTo ? hit.distance : 0f;

            if(currentDistance > distanceTo) {
                newPosition = hit.point;
            } else {
                newPosition = transform.position;
            }

        }
        if(newPosition != Vector3.zero) {
            float distanceCurrent = Vector3.Distance(newPosition, transform.position);
            if (distanceCurrent >= 2f) {
                rb.MovePosition(rb.position + transform.forward * speed * Time.deltaTime);
            }
        }
        if (currentDistance == 0f || newPosition == transform.position) {
            Quaternion deltaRotation = Quaternion.Euler(0f, turnspeed * Time.deltaTime, 0f);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }


        Debug.DrawLine(transform.position, hit.point);
    }


    private void OnTriggerStay(Collider other) {
        currentDistance = 0f;
    }

    public float GetValueLife() {
        return health;
    }

    public void reparing(float life) {
        health += life;
    }
}
