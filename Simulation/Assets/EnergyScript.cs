using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyScript : MonoBehaviour
{


    public Slider slider;

    public void SetEnergy(double energy)
    {
        slider.value = Convert.ToInt32(energy);
    }
}
