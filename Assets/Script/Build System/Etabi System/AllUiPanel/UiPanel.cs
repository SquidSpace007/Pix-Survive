using UnityEngine;
using System.Collections;

public class UiPanel : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Inventory inventory;
    private Build_System buildSystem;

    public GameObject inventoryStorage;
    public GameObject ConstructionPannel;
    public GameObject InventoryPanel;
    public GameObject ElectriqueComposantMenu;
    public GameObject[] allObjects;

    private void Start()
    {
        ElectriqueComposantMenu.SetActive(false);
        playerMovement = FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>();
        buildSystem = FindObjectOfType<Build_System>().GetComponent<Build_System>();
        inventory = FindObjectOfType<Inventory>().GetComponent<Inventory>();
    }

    // Zone De Construction
    public void CraftAxe()
    {
        if(Inventory.ressource[0] >= 5 && playerMovement.haveItAPick == false)
        {
            playerMovement.haveItAAxe = true;
            Inventory.RemoveRessource(0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            CloseTab();
        }
    }

    public void CraftPick()
    {
        if(Inventory.ressource[0] >= 5 && Inventory.ressource[1] >= 6 && playerMovement.haveItAPick == false)
        {
            playerMovement.haveItAPick = true;
            Inventory.RemoveRessource(0, 0, 6, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            CloseTab();
        }
    }

    public void CraftSword()
    {
        if (Inventory.ressource[0] >= 6 && Inventory.ressource[1] >= 3 && playerMovement.haveItASword == false)
        {
            playerMovement.haveItASword = true;
            Inventory.RemoveRessource(0, 0, 3, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            CloseTab();
        }
    }

    public void CraftHammer()
    {
        if(Inventory.ressource[0] >= 5 && Inventory.ressource[1] >= 7 && buildSystem.haveItAHmmer == false)
        {
            buildSystem.haveItAHmmer = true;
            Inventory.RemoveRessource(5, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            CloseTab();
        }
    }
    // Fin de Zone de Construction
        
    void CloseTab()
    {
        for(int i = 0; i < allObjects.Length - 1; i++)
        {
            allObjects[i].SetActive(false);
        }
    }

    //Zone De fermeture / Ouverture des différent Tab
    public void OpenInventory()
    {
        StartCoroutine(Active(allObjects, inventoryStorage));
    }

    public void OpenConstructionPannel()
    {
        StartCoroutine(Active(allObjects, ConstructionPannel));
    }

    public void OpenElectronicComponentPannel()
    {
        StartCoroutine(Active(allObjects, ElectriqueComposantMenu));
    }

    public IEnumerator Active(GameObject[] allObject, GameObject objectToActive)
    {
        for(int i = 0; i <= allObject.Length; i++)
        {
            allObject[i].SetActive(false);
            yield return new WaitForSeconds(0.01f);
            objectToActive.SetActive(true);
        }
    }
}
