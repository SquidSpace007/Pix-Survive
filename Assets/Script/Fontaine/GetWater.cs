using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GetWater : MonoBehaviour
{
    public bool isItWater;
    public int waterToGive;
    public int waitTimes;
    public Inventory inventory;
    public Text errorText;

    // Start is called before the first frame update
    void Start()
    {
        isItWater = true;
        errorText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.SetActive(false);
            gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && isItWater == true)
        {
            Inventory.AddRessource(3, waterToGive);
            StartCoroutine(WaitBeforeCanHaveWater());
        }

        if (collision.CompareTag("Player") && isItWater == false)
        {
            errorText.text = "Erreur tu dois attendre avant d'avoir de l'eau";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        errorText.text = "";
    }

    public IEnumerator WaitBeforeCanHaveWater()
    {
        yield return new WaitForSeconds(0.1f);
        isItWater = false;
        yield return new WaitForSeconds(waitTimes);
        isItWater = true;
        gameObject.SetActive(false);
        gameObject.SetActive(true);
    }
}
