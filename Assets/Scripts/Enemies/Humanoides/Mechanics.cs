using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Mechanics : Human, IDamage {
    [SerializeField] private List<EnemyTank> TanksAliados;
    [SerializeField] private Transform ObjectPoint;
    [SerializeField] private Transform[] Points;
    int index = 0;

    [SerializeField] private bool JobON = false;

    private float currentSpaneo = 0f;
    public float MaxSpaneo = 2f;
    public float ValueHeald = 2f;

    protected new void Start() {
        base.Start();
        TanksAliados.AddRange(FindObjectsByType<EnemyTank>(FindObjectsSortMode.None));
        if (Points.Length > 0) {
            _agent.SetDestination(Points[index].position);
            ObjectPoint = Points[index].transform;
        }

    }

    private void Update() {
        if(_life > 0) {
            moving();
        }

        _anim.SetBool("IsLife", _life >= 1);
    }

    protected override void moving() {
        if (JobON) {
            Debug.Log("LLendo a reparar");
            if (ObjectPoint != null) {
                IHealding victima = ObjectPoint.GetComponent<IHealding>();
                IGetLife tank = ObjectPoint.GetComponent<IGetLife>();
                if (victima != null && tank != null) {
                    if (!_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance && _agent.velocity.sqrMagnitude < 0.01f) {
                        Debug.Log("Inicio de reparacion");
                        currentSpaneo += Time.deltaTime;
                        currentSpaneo = Mathf.Clamp(currentSpaneo, 0f, MaxSpaneo);
                        if (currentSpaneo >= MaxSpaneo) {
                            currentSpaneo = 0f;
                            victima.reparing(2f);
                        }

                        if (tank.GetValueLife() >= 100f) {
                            Debug.Log("Reparación completada");
                            JobON = false;

                            index = (index + 1) % Points.Length;
                            ObjectPoint = Points[index];
                            _agent.SetDestination(ObjectPoint.position);
                        }
                        _anim.SetBool("InJob", JobON);

                    }

                }

            }
        } else {
            if (!_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance) {
                if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f) {
                    index = (index + 1) % Points.Length;
                    ObjectPoint = Points[index];
                    _agent.SetDestination(ObjectPoint.position);
                }
            }
        }
        _anim.SetBool("IsRunning", _agent.velocity.sqrMagnitude >= 0.01f);
        _anim.SetFloat("Distance", (ObjectPoint.position - transform.position).sqrMagnitude);        
    }

    private void OnTriggerStay(Collider other) {
        IGetLife tank = other.GetComponent<IGetLife>();
        EnemyTank enemyTank = other.GetComponent<EnemyTank>();
        if (!JobON) {
            if (tank != null && enemyTank != null) {
                float vida = tank.GetValueLife();
                if (vida < 99f && vida > 1f) {
                    JobON = true;
                    ObjectPoint = enemyTank.transform;
                    _agent.SetDestination(ObjectPoint.position);
                    Debug.Log("TANQUE HERIDO DETECTADO");
                }
            }
        }

    }

    public void Getdamage(float damage) {
        _life -= damage;
        Debug.Log("Me saco vida, tengo: " + _life);
    }
}
