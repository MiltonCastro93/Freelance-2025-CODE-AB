using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour, IObserver
{
    public Slider lifeUI;
    public GameObject Icon1, Icon2;
    public Slider Icon1Slider, Icon2Slider;
    private Color _colorSeleccion = new Color(1f, 1f, 1f, 0.4f);
    private Color _desSeleccion = new Color(0f, 0f, 0f, 0.4f);
    public TextMeshProUGUI info;
    public GameObject PanelGame;
    public TextMeshProUGUI infoPartida;

    private void Awake() {
        GameManager.Instancia.AddObserver(this);
    }


    public void CanvasLife(float life) {
        lifeUI.value = life / 100f;
        
        if(lifeUI.value <= 0) {
            PanelGame.SetActive(lifeUI.value <= 0 ? true : false);
            infoPartida.text = "PERDISTE!";
        }
    }

    public void selection1() {
        Icon1.GetComponent<Image>().color = _colorSeleccion;
        Icon2.GetComponent<Image>().color = _desSeleccion;
        Icon1Slider.enabled = true;
        Icon2Slider.enabled = false;
    }

    public void selection2() {
        Icon1.GetComponent<Image>().color = _desSeleccion;
        Icon2.GetComponent<Image>().color = _colorSeleccion;
        Icon1Slider.enabled = false;
        Icon2Slider.enabled = true;
    }


    public void sliderAmmo1(float progre) {
        Icon1Slider.value = progre / 100f;
        Icon2Slider.value = progre / 100f;
    }

    public void textNotice(bool compare) {
        if (compare) {
            info.text = "(R)ecargar!";
        } else {
            info.text = "Listo!";
        }


    }

    public void score(bool winner) {
        if (winner) {
            PanelGame.SetActive(true);
            infoPartida.text = "Ganaste!";
        }
    }
}
