using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swichbullet : MonoBehaviour {
    public float reloadTime = 0f;
    [SerializeField] private float realoadHE = 2f, realoadAP = 4f;
    [SerializeField] List<GameObject>bullets = new List<GameObject>();

    private GameObject bulletSelection;
    private bool fireOk = false, reaload = false, ChamberEmpty = false;
    private AudioSource[] SoundsPlay = new AudioSource[2];

    // Start is called before the first frame update
    void Start() {
        SoundsPlay = GetComponents<AudioSource>();
        bulletSelection = bullets[0];
        fireOk = true;
        ChamberEmpty = false;       
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetButtonDown("Fire1") && fireOk) {
            fireOk = false;
            ChamberEmpty = true;
            GameManager.Instancia.stateChamber(ChamberEmpty);
            GameObject instancia = Instantiate(bulletSelection,transform.position,transform.rotation);

            IChangety proyectil = instancia.GetComponent<IChangety>();
            proyectil.swichbullet();
            SoundsPlay[0].Play();
        }

        if (Input.GetKeyDown(KeyCode.R) && ChamberEmpty) {
            reaload = true;
            GameManager.Instancia.stateChamber(!ChamberEmpty);
        }


        if (Input.GetButtonDown("Fire2") && ChamberEmpty)  {
            reaload = true;
            if (bulletSelection == bullets[0]) {
                changetoAP();
            } else {
                changetoHE();
            }


        }

        if (reaload) {
            SoundsPlay[1].Play();
            reloadTime += Time.deltaTime;
            if (bulletSelection == bullets[0]) {
                reloadTime = Mathf.Clamp(reloadTime, 0f, realoadHE);
                if(reloadTime >= realoadHE) {
                    reloadTime = 0f;
                    reaload = false;
                    fireOk = true;
                }
            } else {
                reloadTime = Mathf.Clamp(reloadTime, 0f, realoadAP);
                if (reloadTime >= realoadAP) {
                    reloadTime = 0f;
                    reaload = false;
                    fireOk = true;
                }
            }

            GameManager.Instancia.sliderAmmo(reloadTime);
        }

    }



    private void changetoHE() {
        bulletSelection = bullets[0];
        GameManager.Instancia.selectionAmmo(true);
    }

    private void changetoAP() {
        bulletSelection=bullets[1];
        GameManager.Instancia.selectionAmmo(false);
    }

}
