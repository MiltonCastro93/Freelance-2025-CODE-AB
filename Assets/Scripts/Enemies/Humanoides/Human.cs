using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Human : MonoBehaviour
{
    protected Animator _anim;
    protected NavMeshAgent _agent;
    protected float _life = 100f;
    protected float _speed;

    protected void Start() {
        _anim = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }

    protected abstract void moving();


}
