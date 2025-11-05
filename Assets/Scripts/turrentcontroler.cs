using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turrentcontroler : MonoBehaviour
{
    [SerializeField]private GameObject respawnbullet;
    private Rigidbody rb;
    private float turn;
    private float turninput;
    
    // Start is called before the first frame update
    void Start() {
        respawnbullet = transform.GetChild(0).gameObject;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        turninput = Input.GetAxis("Mouse X");
        Vector3 direction=Vector3.up*turninput;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(direction * turn * 8 * Time.deltaTime));

    }
    public GameObject passdata(float turnspeed) {
        turn = turnspeed;
        return respawnbullet;
    }

}
