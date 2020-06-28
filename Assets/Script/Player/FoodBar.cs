using UnityEngine;
using UnityEngine.UI;

public class FoodBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;

    public void SetMaxFood(int food)
    {
        slider.maxValue = food;
        slider.value = food;
    }

    public void SetFood(int food)
    {
        slider.value = food;
    }
}
