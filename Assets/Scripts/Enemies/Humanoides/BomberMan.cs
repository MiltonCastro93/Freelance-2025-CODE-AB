using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberMan : Human,IDamage
{
    protected GameObject _player;
    public float danioExplo = 25f;
    public float stopDistance = 3f;

    private enum Estado { Idle, Persiguiendo, Explotando }
    private Estado estadoActual = Estado.Idle;

    private void Update() {
        if (_life >= 1 && _player != null) {
            switch (estadoActual) {
                case Estado.Persiguiendo:
                    moving();
                    break;
                case Estado.Explotando:
                    Explotar();
                    break;
            }

            _anim.SetBool("IsRunning", _agent.velocity.sqrMagnitude >= 0.01f);
        }

        _anim.SetBool("IsDead", _life == 0);
    }

    private void Explotar() {
        if (_player != null) {
            _player.GetComponent<IDamage>().Getdamage(danioExplo);
            Debug.Log("¡BOOM!");
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            _player = other.GetComponent<playermovement>().gameObject;
            estadoActual = Estado.Persiguiendo;
        }
    }

    public void Getdamage(float damage) {
        _life -= damage;
    }

    protected override void moving() {
        if (_player != null) {
            Vector3 directionToPlayer = (_player.transform.position - transform.position).normalized;
            Vector3 stopPosition = _player.transform.position - directionToPlayer * stopDistance;

            _agent.SetDestination(stopPosition);

            if (!_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance && _agent.velocity.sqrMagnitude < 0.01f) {
                estadoActual = Estado.Explotando;
            }
        }


    }
}
