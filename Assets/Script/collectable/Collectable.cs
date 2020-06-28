using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour
{
    public enum Mode { rock, wood, iron, coal, copper, gold, food}
    public Mode mode;

    public int randomLoot;
    public int loot;
    public int randomDura;
    public int Dura;

    public int maxDura;
    public int minDura;

    public int maxLoot;
    public int minLoot;

    public bool isBlocked;
    public bool isThatARessource;

    public Inventory inventory;
    public ToolsManagement toolsManagement;

    // Start is called before the first frame update
    void Start()
    {
        if(mode == Mode.food)
        {
            isThatARessource = false;
        }
        else
        {
            isThatARessource = true;
        }
        isBlocked = false;
        randomDura = Random.Range(minDura, maxDura);
        Dura = randomDura;
        randomLoot = Random.Range(minLoot, maxLoot);
        loot = randomLoot;
    }

    // Update is called once per frame
    void Update()
    {
        if(Dura <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (mode == Mode.wood && collision.CompareTag("AxeCollider") && isBlocked == false) 
        {
            Add(0, 0);
        }
        if (mode == Mode.rock && collision.CompareTag("pickCollider") && isBlocked == false) 
        {
            Add(1, 1);
        }
        if (mode == Mode.coal && collision.CompareTag("pickCollider") && isBlocked == false) 
        {
            Add(3, 1);
        }
        if (mode == Mode.copper && collision.CompareTag("pickCollider") && isBlocked == false) 
        {
            Add(4, 1);
        }
        if (mode == Mode.iron && collision.CompareTag("pickCollider") && isBlocked == false) 
        {
            Add(5, 1);
        }
        if (mode == Mode.food && collision.CompareTag("FoodSource") && isBlocked == false) 
        {
            Add(2, 2);
        }
        if (mode == Mode.gold && collision.CompareTag("pickCollider") && isBlocked == false)
        {
            Add(7, 1);
        }

        void Add(int itemID, int toolsManagementId)
        {
            Inventory.AddRessource(itemID, loot);
            randomLoot = Random.Range(minLoot, maxLoot);
            loot = randomLoot;
            float randomWaitTimes = Random.Range(1f, 3f);
            StartCoroutine(WaitBeforeIsNotBlocked(randomWaitTimes));
            toolsManagement.durability[toolsManagementId] -= 1;
            Dura -= 1;
        }
    }

    public IEnumerator WaitBeforeIsNotBlocked(float waitTimes)
    {
        isBlocked = true;
        yield return new WaitForSeconds(waitTimes);
        isBlocked = false;
        gameObject.SetActive(false);
        gameObject.SetActive(true);
    }
}
