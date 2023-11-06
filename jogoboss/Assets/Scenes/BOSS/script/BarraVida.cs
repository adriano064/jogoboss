using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    public int HealthMax
    {
        set
        {
            this.slider.maxValue = value;
        }
    }

    public int Health
    {
        set
        {
            this.slider.value = value;
        }
    }
   
}
