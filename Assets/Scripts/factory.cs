using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class factory : MonoBehaviour
{
   [SerializeField] protected float health = 100;
    [SerializeField] protected float speed = 1;
    [SerializeField] protected float turnspeed = 1;
    [SerializeField] protected float turretspeed = 1;

    protected abstract void movement();
    protected abstract void fire();


}
