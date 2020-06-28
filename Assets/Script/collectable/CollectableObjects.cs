using System.Collections;
using UnityEngine;

public class CollectableObjects : MonoBehaviour
{
    public GameObject e;
    public bool canCollect;

    public Inventory inventory;

    public enum Mode { rock, wood}
    public Mode mode;

    // Start is called before the first frame update
    void Start()
    {
        canCollect = false;
        e.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(ActiveOrDesactive());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            e.SetActive(true);
        }
        if(mode == Mode.rock && canCollect == true && collision.CompareTag("Player"))
        {
            Inventory.AddRessource(1, 1);
            Destroy(gameObject);
        }else if(mode == Mode.wood && canCollect == true && collision.CompareTag("Player"))
        {
            Inventory.AddRessource(0, 1);
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        e.SetActive(false);
    }

    private IEnumerator ActiveOrDesactive()
    {
        canCollect = true;
        gameObject.SetActive(false);
        gameObject.SetActive(true);
        yield return new WaitForSeconds(0.001f);
        canCollect = false;
    }
}
