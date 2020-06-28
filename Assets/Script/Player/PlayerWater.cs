using UnityEngine;
using System.Collections;

public class PlayerWater : MonoBehaviour
{
    public int maxWater = 100;
    public int currentWater;
    public float wait;

    public WaterBar waterBar;
    public PlayerHealth playerHealth;
    public Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        currentWater = maxWater;
        waterBar.SetMaxHealth(maxWater);
        TakeDownWater();
    }

    // Update is called once per frame
    void Update()
    {
        wait = 25f;
        
        if(currentWater == 0)
        {
            playerHealth.currentHealth -= 1;
        }

        if(currentWater < 0)
        {
            playerHealth.currentHealth -= 1;
        }

        if (Input.GetKeyDown(KeyCode.AltGr))
        {
            currentWater -= 20;
            waterBar.SetHealth(currentWater);
        }
    }

    void TakeDownWater()
    {
        StartCoroutine(TakeDownWater0());
    }

    public IEnumerator TakeDownWater0()
    {
        wait = 25f;
        yield return new WaitForSeconds(25f);
        currentWater -= 1;
        waterBar.SetHealth(currentWater);
        TakeDownWater();
    }
}
