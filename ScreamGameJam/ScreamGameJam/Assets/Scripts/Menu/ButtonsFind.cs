using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsFind : MonoBehaviour
{
    public enum Sett { masterr, ambient, events, sens}
    public Sett SetToButton;
    void Start()
    {
        Menu menu = FindObjectOfType<Menu>();
        Slider slider = gameObject.GetComponent<Slider>();
        switch (SetToButton)
        {
            case Sett.masterr:
                slider.onValueChanged.AddListener((value) => { menu.MasterMixer(slider); });
                break;
            case Sett.ambient:
                slider.onValueChanged.AddListener((value) => { menu.AmdientSound(slider); });
                break;
            case Sett.events:
                slider.onValueChanged.AddListener((value) => { menu.EventsSounds(slider); });
                break;
            case Sett.sens:
                slider.onValueChanged.AddListener((value) => { menu.MouseSens(slider); });
                break;
            default:
                break;
        }
    }

}
