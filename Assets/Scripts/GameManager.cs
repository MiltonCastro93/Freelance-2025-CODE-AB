using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager instance;
    public static GameManager Instancia => instance;
    private List<IObserver> observers = new List<IObserver>();
    private float lifeCurrent;
    private float progreReload;
    private bool typeAmmo, vacio;
    private int puntos = 0;

    private void Awake() {
        if(instance == null) {
            instance = this;
            lifeCurrent = 100f;
            vacio = false;
            updateNotification();
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }


    }


    public void AddObserver(IObserver observer) {
        if (!observers.Contains(observer)) {
            observers.Add(observer);
        }
    }

    private void RemoveObserver(IObserver observer) {
        if (observers.Contains(observer)) {
            observers.Remove(observer);
        }
    }
    
    public void LifeNotification(float life) {
        lifeCurrent -= life;
        lifeCurrent = Mathf.Clamp(lifeCurrent, 0f, 100f);
        updateNotification();
    }


    private void updateNotification() {
        foreach (IObserver observer in observers) {
            observer.CanvasLife(lifeCurrent);
            observer.sliderAmmo1(progreReload);
            observer.textNotice(vacio);
            observer.score(puntos >= 3);
            if (typeAmmo) {
                observer.selection1();
            } else {
                observer.selection2();
            }
        }
    }

    public void selectionAmmo(bool seleccion) {
        typeAmmo = seleccion;
        updateNotification();
    }

    public void sliderAmmo(float currentProgre) {
        progreReload += currentProgre;
        if(currentProgre <= 0f) {
            progreReload = 0f;
        }
        updateNotification();
    }

    public void stateChamber(bool state) {
        vacio = state;
        updateNotification();
    }

    public void conditionWinner(int score) {
        puntos += score;
    }

}
