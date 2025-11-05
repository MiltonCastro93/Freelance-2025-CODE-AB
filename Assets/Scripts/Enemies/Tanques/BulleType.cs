using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulleType : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float currentTimeReload = 0f, TimeMaxReload = 2f;

    public void BulletON(bool fire) {
        if (fire) {
            currentTimeReload += Time.deltaTime;
            currentTimeReload = Mathf.Clamp(currentTimeReload, 0, TimeMaxReload);
            if(currentTimeReload >= TimeMaxReload) {
                GameObject game = Instantiate(bullet,transform.position, transform.rotation);
                currentTimeReload = 0;
            }

        }
    }

}
