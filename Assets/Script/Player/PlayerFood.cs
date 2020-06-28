using System.Collections;
using UnityEngine;

public class PlayerFood : MonoBehaviour
{
    public int currentFood;
    public int maxFood = 100;

    public FoodBar foodBar;
    public PlayerHealth playerHealth;
    public HealthBar healthBar;
    public Inventory inventory;

    public int nbFood;

    // Start is called before the first frame update
    void Start()
    {
        currentFood = maxFood;
        foodBar.SetMaxFood(maxFood);
        TakeDownFood();
        //nbFood = Inventory.nbFood;
    }

    void Update()
    {
        //nbFood = Inventory.nbFood;

        if (currentFood == 100)
        {
            currentFood = 100;
            foodBar.SetFood(currentFood);
        }

        if(currentFood == 0)
        {
            playerHealth.currentHealth -= 1;
            healthBar.SetHealth(playerHealth.currentHealth);
        }

        if(currentFood < 0)
        {
            playerHealth.currentHealth -= 1;
            healthBar.SetHealth(playerHealth.currentHealth);
        }

        if(currentFood > 100)
        {
            currentFood = 100;
        }
    }

    void TakeDownFood()
    {
        currentFood -= 1;
        foodBar.SetFood(currentFood);
        StartCoroutine(TakeDownFoodNow());
    }

    public IEnumerator TakeDownFoodNow()
    {
        yield return new WaitForSeconds(30f);
        TakeDownFood();
    }
}
