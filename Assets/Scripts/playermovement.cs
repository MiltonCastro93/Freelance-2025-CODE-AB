using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class playermovement : factory, IDamage {

    protected Rigidbody _rb;
    protected float inputX, inputZ;
    protected GameObject respawn;
    protected bool chaf;
    private bool IsDead = false;
    private AudioSource _aS;
    [SerializeField] private AudioClip[] sounds;

    // Start is called before the first frame update
    void Start() {
        _rb = GetComponent<Rigidbody>();
        _aS = GetComponent<AudioSource>();
        respawn = GetComponentInChildren<turrentcontroler>().passdata(turretspeed);
    }

    // Update is called once per frame
    void Update() {
        health = Mathf.Clamp(health, 0f, 100f);        
    }

    private void FixedUpdate() {
        if (health >= 1) {
            movement();
            fire();
        } else if(!IsDead){
            IsDead = true;
            GetComponentInChildren<swichbullet>().enabled = false;
        }
    }

    protected override void fire() {
        if (Input.GetKeyDown(KeyCode.E)) {
            //Tirar chaf, con tiempo cronometrado y podria poner un changety para cambiar entre habilidades?
        }

    }

    protected override void movement() {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");
        Vector3 turndirection = Vector3.up * inputX;      
            
        _rb.MovePosition(_rb.position + transform.forward * inputZ * Time.deltaTime * speed);
        _rb.MoveRotation(_rb.rotation * Quaternion.Euler(turndirection * speed*8*Time.deltaTime));
        sonidos();
             
    }

    public void Getdamage(float damage) {
        health -= damage;
        GameManager.Instancia.LifeNotification(damage);
    }

    private void sonidos() {
        if (inputZ <= 0f) {
            _aS.clip = sounds[0];
            _aS.pitch = 1f;
            _aS.Play();
        } else {
            _aS.clip = sounds[1];
            _aS.pitch = Mathf.Clamp(Random.Range(-1f, 1f), -1, 1);
            _aS.Play();
        }
    }

}
