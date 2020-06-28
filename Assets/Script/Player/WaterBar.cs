using UnityEngine;
using UnityEngine.UI;

public class WaterBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int water)
    {
        slider.maxValue = water;
        slider.value = water;
    }

    public void SetHealth(int water)
    {
        slider.value = water;
    }
}
