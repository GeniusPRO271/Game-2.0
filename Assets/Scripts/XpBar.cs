using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{

    public Slider slider;


    public void SetMaxXp(int xp,int leftxp)
    {
        slider.maxValue = xp;
        slider.value = leftxp;

    }
    public void SetXP(int xp)
    {
        slider.value = xp;
    }
}
